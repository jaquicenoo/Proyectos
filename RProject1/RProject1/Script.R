
sqlShareDir <- paste("C:\\AllShare\\", Sys.getenv("USERNAME"), sep = "")
sqlWait <- TRUE
sqlConsoleOutput <- FALSE
sqlcc <- RxInSqlServer(connectionString = settings$dbConnection7, shareDir = sqlShareDir, wait = sqlWait, consoleOutput = sqlConsoleOutput)
rxSetComputeContext(sqlcc)
sampleDataQuery <- "SELECT tipped, fare_amount, passenger_count,trip_time_in_secs,trip_distance, pickup_datetime, dropoff_datetime, pickup_longitude, pickup_latitude, dropoff_longitude, dropoff_latitude FROM nyctaxi_sample"
inDataSource <- RxSqlServerData(
  sqlQuery = sampleDataQuery,
  connectionString = settings$dbConnection7,
  colClasses = c(pickup_longitude = "numeric", pickup_latitude = "numeric",
  dropoff_longitude = "numeric", dropoff_latitude = "numeric"),
  rowsPerRead = 500
  )
mapPlot <- function(inDataSource, googMap) {
    ds <- rxImport(inDataSource)
    p <- ggmap(googMap) +
    geom_point(aes(x = pickup_longitude, y = pickup_latitude), data = ds, alpha = .5,
    color = "darkred", size = 1.5)
    return(list(myplot = p))
}
rxSetComputeContext("local")
library(ggmap)
library(mapproj)

gc <- geocode("Times Square", source = "google")
googMap <- get_googlemap(center = as.numeric(gc), zoom = 12, maptype = 'roadmap', color = 'color');
rxSetComputeContext(sqlcc)
myplots <- rxExec(mapPlot, inDataSource, googMap, timesToRun = 1)
ds <- rxImport(inDataSource)
p <- ggmap(googMap) +
    geom_point(aes(x = pickup_longitude, y = pickup_latitude), data = ds, alpha = .5,
    color = "darkred", size = 1.5)
j <- list(myplot = p)
plot(j[[1]][["myplot"]]);

#-----------------------------
bigQuery <- "SELECT tipped, fare_amount, passenger_count,trip_time_in_secs,trip_distance, pickup_datetime, dropoff_datetime,  pickup_latitude, pickup_longitude,  dropoff_latitude, dropoff_longitude FROM nyctaxi_sample";
featureDataSource <- RxSqlServerData(sqlQuery = bigQuery, colClasses = c(pickup_longitude = "numeric", pickup_latitude = "numeric", dropoff_longitude = "numeric", dropoff_latitude = "numeric", passenger_count = "numeric", trip_distance = "numeric", trip_time_in_secs = "numeric", direct_distance = "numeric"), connectionString = settings$dbConnection7);

env <- new.env();
env$ComputeDist <- function(pickup_long, pickup_lat, dropoff_long, dropoff_lat) {
    R <- 6371 / 1.609344 #radius in mile
    delta_lat <- dropoff_lat - pickup_lat
    delta_long <- dropoff_long - pickup_long
    degrees_to_radians = pi / 180.0
    a1 <- sin(delta_lat / 2 * degrees_to_radians)
    a2 <- as.numeric(a1) ^ 2
    a3 <- cos(pickup_lat * degrees_to_radians)
    a4 <- cos(dropoff_lat * degrees_to_radians)
    a5 <- sin(delta_long / 2 * degrees_to_radians)
    a6 <- as.numeric(a5) ^ 2
    a <- a2 + a3 * a4 * a6
    c <- 2 * atan2(sqrt(a), sqrt(1 - a))
    d <- R * c
    return(d)
}
rxSetComputeContext("local");


start.time <- proc.time();

featureEngineeringQuery = "SELECT tipped, fare_amount, passenger_count,
    trip_time_in_secs,trip_distance, pickup_datetime, dropoff_datetime,
    dbo.fnCalculateDistance(pickup_latitude, pickup_longitude,  dropoff_latitude, dropoff_longitude) as direct_distance,
    pickup_latitude, pickup_longitude,  dropoff_latitude, dropoff_longitude
    FROM nyctaxi_sample
    tablesample (1 percent) repeatable (98052)"
featureDataSource = RxSqlServerData(sqlQuery = featureEngineeringQuery,
  colClasses = c(pickup_longitude = "numeric", pickup_latitude = "numeric",
         dropoff_longitude = "numeric", dropoff_latitude = "numeric",
         passenger_count = "numeric", trip_distance = "numeric",
          trip_time_in_secs = "numeric", direct_distance = "numeric"),
  connectionString = settings$dbConnection7)

rxGetVarInfo(data = featureDataSource)


changed_ds <- rxDataStep(inData = featureEngineeringQuery,
transforms = list(direct_distance = ComputeDist(pickup_longitude, pickup_latitude, dropoff_longitude, dropoff_latitude),
tipped = "tipped", fare_amount = "fare_amount", passenger_count = "passenger_count",
trip_time_in_secs = "trip_time_in_secs", trip_distance = "trip_distance",
pickup_datetime = "pickup_datetime", dropoff_datetime = "dropoff_datetime"),
transformEnvir = env,
rowsPerRead = 500,
reportProgress = 3);

used.time <- proc.time() - start.time;
print(paste("It takes CPU Time=", round(used.time[1] + used.time[2], 2), " seconds, Elapsed Time=", round(used.time[3], 2), " seconds to generate features.", sep = ""));


system.time(logitObj <- rxLogit(tipped ~ passenger_count + trip_distance + trip_time_in_secs + direct_distance, data = ds));


scoredOutput <- RxSqlServerData(
  connectionString = settings$dbConnection7,
  table = "taxiScoreOutput")

