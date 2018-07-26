using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PruebaAviones
{
    public static class ApiRest
    {
        public static HttpClient WebService = new HttpClient();

        static ApiRest()
        {
            WebService.BaseAddress = new Uri("http://localhost:62667/api/");
            WebService.DefaultRequestHeaders.Clear();
            WebService.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}