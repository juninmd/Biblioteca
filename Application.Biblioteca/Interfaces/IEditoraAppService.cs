using Domain.Biblioteca.Editora;
using System.Net.Http;

namespace Application.Biblioteca.Interfaces
{
    public interface IEditoraAppService
    {
        HttpResponseMessage Post(EditoraDto editora);
        HttpResponseMessage Get(int? idEditora = null);
        HttpResponseMessage GetById(int? idEditora = null);
        HttpResponseMessage Delete(int idEditora);
        HttpResponseMessage Put(EditoraDto editora);

    }
}
