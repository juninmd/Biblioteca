using Application.Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Biblioteca.Livro;
using System.Net.Http;

namespace Application.Biblioteca.Services
{
    public class LivroAppService : ILivroAppService
    {
        public HttpResponseMessage Delete(int idAutor)
        {
            return BaseAppService.Delete("http://localhost:5002/api/Livro?idLivro=" + idAutor);
        }

        public HttpResponseMessage Get(int? idAutor = null)
        {
            return BaseAppService.Get("http://localhost:5002/api/Livro");
            //var cliente = new HttpClient();
            //return cliente.GetAsync("http://localhost:5002/api/Livro").Result;
        }

        public HttpResponseMessage Post(LivroDto livro)
        {
            return BaseAppService.Post("http://localhost:5002/api/Livro/Post", livro);
        }

        public HttpResponseMessage Put(LivroDto livro)
        {
            return BaseAppService.Put("http://localhost:5002/Livro/Put", livro, livro.idLivro);
        }


    }
}
