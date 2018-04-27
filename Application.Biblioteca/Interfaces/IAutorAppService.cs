using Domain.Biblioteca.Autor;
using System.Net.Http;

namespace Application.Biblioteca.Interfaces
{
    public interface IAutorAppService
    {
        HttpResponseMessage Post(object autor);
        HttpResponseMessage Get(int? idAutor = null);
        HttpResponseMessage GetById(int? idAutor = null);
        HttpResponseMessage Delete(int idAutor);
        HttpResponseMessage Put(AutorDto autor);
    }
}
