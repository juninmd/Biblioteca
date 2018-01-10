using Domain.Biblioteca.Editora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Biblioteca.Interfaces
{
    public interface IEditoraAppService
    {
        HttpResponseMessage Post(EditoraDto editora);
        HttpResponseMessage Get(int? idEditora = null);
        HttpResponseMessage GetById(int idEditora);
        HttpResponseMessage Delete(int idEditora);
        HttpResponseMessage Put(EditoraDto editora);
    }
}
