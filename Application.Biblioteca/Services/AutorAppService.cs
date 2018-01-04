using Application.Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Biblioteca.Autor.dtoAutor;
using System.Net.Http;

namespace Application.Biblioteca.Services
{
    public class AutorAppService : IAutorAppService
    {        
        public HttpResponseMessage Delete(int? idAutor = null)
        {
            return BaseAppService.Delete("http://localhost:5001/Autor/Delete" + idAutor);
        }

        public HttpResponseMessage Get(int? idAutor = null)
        {
            return BaseAppService.Get("http://localhost:5001/Autor/Get");
        }

        public HttpResponseMessage Post(object autor)
        {
            return BaseAppService.Post("http://localhost:5001/Autor/Post", autor);
        }

        public HttpResponseMessage Put(AutorDto autor)
        {
            return BaseAppService.Put("http://localhost:5001/Autor/Put", autor, autor.idAutor);
        }

    }
}
