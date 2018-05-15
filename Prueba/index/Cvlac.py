'''
Created on 14/05/2018
@author: jhon quiceno
'''
import scrapy

class cvlacItem(scrapy.Item):

    categoria = scrapy.Field()
    nombre = scrapy.Field()
    nombrecitaciones= scrapy.Field()
    nacionalidad = scrapy.Field()
    sexo = scrapy.Field()
    
    pass

