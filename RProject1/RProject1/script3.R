﻿ #librerias Instaladas - solo se hace una vez
install.packages("RSocrata") #Datos abiertos
install.packages("doBy")
install.packages("shiny")
install.packages("plotly")
install.packages("xlsx")
#limpio variables en el ambiente de desarrollo
rm(list = ls(all = TRUE))
#multiprocesos
set.seed(123)

#Cargo librerias
library("RSocrata") #para hacer la conexión con datos abiertos
library("doBy") #generar estadistica descriptiva con grupos
library("shiny") #para generar visualizaciones
library(plotly) # visualizaciones

#llamo a datos abiertos
Datos <- "https://www.datos.gov.co/api/odata/v4/wak2-x7sp"
#nombro variables
VW_Datos <- read.socrata(Datos) # extración de los datos de socrata
#valido los primeros datos
head(VW_Datos)
#Cantidad de Registros
registros <- nrow(VW_Datos)
#variables del Dataset
names(VW_Datos)
#realizo Estadistica descriptiva del dataset
summary(VW_Datos)
# hacer analisis de variables
unique(VW_Datos$Valor.Contrato.con.Adiciones)
#hacer analisis con respecto a una variable
summaryBy(Valor.Contrato.con.Adiciones ~ Anno.Cargue.SECOP, data = datos_depurados, FUN = c(length, sum))
#elimino Borradores
filtro <- c("Borrador", "Terminado Anormalmente después de Convocado", "Convocado")
datos_depurados <- subset(VW_Datos, !(VW_Datos$Estado.del.Proceso %in% filtro))
#verifico datos atipicos en valor contrato
boxplot(datos_depurados$Valor.Contrato.con.Adiciones)
datos_depurados1 <- outlierKD(datos_depurados, Cuantia.Proceso)
hist(datos_depurados$Valor.Contrato.con.Adiciones)
# valido Tipos de Procesos
unique(datos_depurados1$Tipo.de.Proceso)
summaryBy(datos_depurados1$Cuantia.Proceso ~ datos_depurados1$Estado.del.Proceso, data = datos_depurados1,
          FUN = c(length))

plot_ly(datos_depurados1, x = datos_depurados1$Tipo.de.Proceso, y = datos_depurados1$Valor.Contrato.con.Adiciones, group = datos_depurados1$Tipo.de.Proceso, type = "bar")
#realizo un subset de datos con solo regimen especial
seleccion <- c("Régimen Especial")
regimen <- subset(datos_depurados1, (datos_depurados1$Tipo.de.Proceso %in% seleccion))
View(regimen)
#Objeto a contratar
summaryBy(regimen$Cuantia.Proceso ~ regimen$Tipo.de.Contrato, data = regimen,
          FUN = c(length, mean))
boxplot(regimen$Cuantia.Proceso)
summary(regimen$Cuantia.Proceso)
hist(regimen$Valor.Contrato.con.Adiciones)
plot_ly(regimen, x = regimen$Tipo.de.Contrato, y = regimen$Valor.Contrato.con.Adiciones, group = regimen$Tipo.de.Proceso, type = "bar")
plot_ly(regimen, x = regimen$Tipo.de.Contrato, y = regimen$Valor.Contrato.con.Adiciones, group = regimen$Tipo.de.Proceso, type = "bar")

library(xlsx)
write.table(mydata, "c:/mydata.txt", sep = "\t")