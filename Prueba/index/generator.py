import scrapy
from scrapy.crawler import CrawlerProcess
from index import CvlacSpider

#10000000000
for i in range(10):
    Myspider = CvlacSpider('i')
    Myspider.start_urls=Myspider.start_urls+1
    process = CrawlerProcess()
    process.crawl(Myspider)
    process.start() # the script will block here until all crawling jobs are finished