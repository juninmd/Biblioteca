using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Application.Biblioteca.Services
{
    public static class BaseAppService
    {
        private static HttpClient _client;

        public static HttpResponseMessage Get(string uri, int? id = null)
        {
            _client = new HttpClient();
            return _client.GetAsync(uri).Result;
        }

        public static HttpResponseMessage GetById(string uri)
        {
            _client = new HttpClient();
            return _client.GetAsync(uri).Result;
        }
        
        public static HttpResponseMessage Post(string uri, object parametros)
        {
            _client = new HttpClient();
            return _client.PostAsync(uri, parametros, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }

            }).Result;
        }

        public static HttpResponseMessage Delete(string uri)
        {
            _client = new HttpClient();
            return _client.DeleteAsync(uri).Result;
        }

        public static HttpResponseMessage Put(string uri, object parametros, int? id)
        {
            HttpContent conteudo = new StringContent(JsonConvert.SerializeObject(parametros));
            _client = new HttpClient();
            return _client.PutAsync(uri, conteudo).Result;
        }
    }
}





