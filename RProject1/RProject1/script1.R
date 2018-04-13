
mu <- 50
stddev <- 1
N <- 10000
pop <- rnorm(N, mean = mu, sd = stddev)

n <- 30
samp.means <- rnorm(N, mean = mu, sd = stddev / sqrt(n))
max.samp.means <- max(density(samp.means)$y)

plot(density(pop), main = "Population Density",
    ylim = c(0, max.samp.means),
    xlab = "X", ylab = "")
lines(density(samp.means))

#if (!('ggmap' %in% rownames(installed.packages()))) { install.packages('ggmap') }
##if (!('mapproj' %in% rownames(installed.packages()))) { install.packages('mapproj') }
#if (!('ROCR' %in% rownames(installed.packages()))) { install.packages('ROCR') }
#if (!('RODBC' %in% rownames(installed.packages()))) { install.packages('RODBC') }
#library("RevoScaleR")
sqlShareDir <- paste("C:\\AllShare\\", Sys.getenv("USERNAME"), sep = "")
sqlWait <- TRUE
sqlConsoleOutput <- FALSE
sqlcc <- RxInSqlServer(connectionString = settings$dbConnection4, shareDir = sqlShareDir, wait = sqlWait, consoleOutput = sqlConsoleOutput)
rxSetComputeContext(sqlcc)
sampleDataQuery <- "SELECT tipped, fare_amount, passenger_count,trip_time_in_secs,trip_distance, pickup_datetime, dropoff_datetime, pickup_longitude, pickup_latitude, dropoff_longitude, dropoff_latitude FROM nyctaxi_sample"
inDataSource <- RxSqlServerData(
  sqlQuery = sampleDataQuery,
  connectionString = settings$dbConnection4,
  colClasses = c(pickup_longitude = "numeric", pickup_latitude = "numeric",
  dropoff_longitude = "numeric", dropoff_latitude = "numeric"),
  rowsPerRead = 500
  )
rxGetVarInfo(data = inDataSource)
start.time <- proc.time()
rxSummary(~fare_amount:F(passenger_count, 1, 6), data = inDataSource)
used.time <- proc.time() - start.time
print(paste("It takes CPU Time=", round(used.time[1] + used.time[2], 2), " seconds,
  Elapsed Time=", round(used.time[3], 2),
  " seconds to summarize the inDataSource.", sep = ""))
# Plot fare amount on SQL Server and return the plot
start.time <- proc.time()
rxHistogram(~fare_amount, data = inDataSource, title = "Fare Amount Histogram")
used.time <- proc.time() - start.time
print(paste("It takes CPU Time=", round(used.time[1] + used.time[2], 2), " seconds, Elapsed Time=", round(used.time[3], 2), " seconds to generate plot.", sep = ""))
mapPlot <- function(inDataSource, googMap) {

    library("ggmap", lib.loc = "C:\\Users\\Tes America\\Documents\\R\\win-library\\3.3")
    library(mapproj)
    ds <- rxImport(inDataSource)
    p <- ggmap(googMap) +
    geom_point(aes(x = pickup_longitude, y = pickup_latitude), data = ds, alpha = .5,
    color = "darkred", size = 1.5)
    return(list(myplot = p))
}
#if (!('ggplot2' %in% rownames(installed.packages()))) { install.packages('ggplot2') }
#if (!('Rcpp' %in% rownames(installed.packages()))) { install.packages('Rcpp') }
install.packages('ggmap', dep = TRUE)
rxSetComputeContext(sqlcc)
library(ggplot2)
library.path <- .libPaths()

myplots <- rxExec(mapPlot, inDataSource, googMap, timesToRun = 1)
plot(myplots[[1]][["myplot"]]);
library()