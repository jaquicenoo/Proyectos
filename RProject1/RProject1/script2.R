rollDice <- function() {
    result <- NULL
    point <- NULL
    count <- 1
    while (is.null(result)) {
        roll <- sum(sample(6, 2, replace = TRUE))

        if (is.null(point)) { point <- roll }
        if (count == 1 && (roll == 7 || roll == 11)) { result <- "Win" }
        else if (count == 1 && (roll == 2 || roll == 3 || roll == 12)) { result <- "Loss" }
        else if (count > 1 && roll == 7) { result <- "Loss" }
        else if (count > 1 && point == roll) { result <- "Win" }
        else { count <- count + 1 }
        }
    result
}
rollDice()
sqlServerExec <- rxExec(rollDice, timesToRun = 20, RNGseed = "auto")
length(sqlServerExec)
table(unlist(sqlServerExec))