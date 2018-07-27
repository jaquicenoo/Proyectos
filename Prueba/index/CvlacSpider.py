# -*- coding: utf-8 -*-
import scrapy
from scrapy.spider import CrawlSpider, Rule
from scrapy.linkextractors import LinkExtractor
from scrapy.exceptions import CloseSpider
from index import Cvlac
from scrapy.crawler import CrawlerProcess


def normalize_whitespace(str):
    import re
    str = str.strip()
    str = re.sub(r'\s+', ' ', str)
    
    return str
class CvlacSpider(scrapy.Spider):
    name = 'cvlac'
    allowed_domains = ['http://scienti.colciencias.gov.co:8081/cvlac']
    start_urls = [] 
    for i in range(10000):
        url = 'http://scienti.colciencias.gov.co:8081/cvlac/visualizador/generarCurriculoCv.do?cod_rh=0000000000'
        start_urls.append(url[0:len(url)-len(str(i))]+str(i))
    def parse(self, response):
        tabla = response.css('table')[1]       
        datos=[]
        for i in tabla.css('td::text').extract():
            datos.append(normalize_whitespace(i))
        yield {
        #'categoria':datos[datos.index('Categoría')+1],
        'nombre':datos[datos.index('Nombre')+1],
        'nombrecitaciones':datos[datos.index('Nombre en citaciones')+1],
        'nacionalidad':datos[datos.index('Nacionalidad')+1],
        'sexo':datos[datos.index('Sexo')+1],
        }
    ...
process = CrawlerProcess()
process.crawl(CvlacSpider)
process.start() # the script will block here until all crawling jobs are finished

        
                
                
            
        




'''
Created on 14/05/2018

@author: jhon quiceno
'''
