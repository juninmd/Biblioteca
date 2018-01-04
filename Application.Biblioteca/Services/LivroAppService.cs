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
        public HttpResponseMessage Delete(int? idAutor = null)
        {
            return BaseAppService.Delete("http://localhost:5001/Livro/Delete?=id" + idAutor);
        }

        public HttpResponseMessage Get(int? idAutor = null)
        {
            return BaseAppService.Get("http://localhost:5001/Livro?/Get" + idAutor);
        }

        public HttpResponseMessage Post(object livro)
        {
            return BaseAppService.Post("http://localhost:5001/Livro/Post", livro);
        }

        public HttpResponseMessage Put(LivroDto livro)
        {
            return BaseAppService.Put("http://localhost:5001/Livro/Put", livro, livro.idLivro);
        }


    }
}
