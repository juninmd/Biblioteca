﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Application.Biblioteca.Services
{
    public static class BaseAppService
    {
        private static HttpClient _client = null;

        public static HttpResponseMessage Get(string uri, int? id = null)
        {
            return _client.GetAsync(uri).Result;
        }

        public static HttpResponseMessage Post(string uri, object parametros)
        {
            return _client.PostAsync(uri, parametros, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }

            }).Result;
        }

        public static HttpResponseMessage Delete(string uri, int? id = null)
        {
            return _client.GetAsync(uri).Result;
        }

        //public static HttpResponseMessage Put(string uri, string nomeEditora, int id)
        //{
        //    HttpContent conteudo = new StringContent(JsonConvert.SerializeObject(nomeEditora));

        //    return _client.PutAsync(uri, conteudo).Result;
        //} 


        public static HttpResponseMessage Put(string uri, object parametros, int id)
        {
            HttpContent conteudo = new StringContent(JsonConvert.SerializeObject(parametros));
            return _client.PutAsync(uri, conteudo).Result;
        }



    }

}





