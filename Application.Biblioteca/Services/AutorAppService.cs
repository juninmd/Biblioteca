using Application.Biblioteca.Interfaces;
using Domain.Biblioteca.Autor;
using System.Net.Http;

namespace Application.Biblioteca.Services
{
    public class AutorAppService : IAutorAppService
    {        
        public HttpResponseMessage Delete(int idAutor)
        {
            return BaseAppService.Delete("http://localhost:5002/api/Autor?idAutor=" + idAutor);
        }

        public HttpResponseMessage Get(int? idAutor = null)
        {
            return BaseAppService.Get("http://localhost:5002/api/Autor");
        }

        public HttpResponseMessage GetById(int? idAutor = null)
        {
            return BaseAppService.GetById("http://localhost:5002/api/Autor?idAutor=" + idAutor);
        }

        public HttpResponseMessage Post(object autor)
        {
            return BaseAppService.Post("http://localhost:5002/api/Autor/Post", autor);
        }

        public HttpResponseMessage Put(AutorDto autor)
        {
            return BaseAppService.Put("http://localhost:5002/api/Autor/Put", autor, autor.idAutor);
        }
    }
}
