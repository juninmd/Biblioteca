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
        HttpResponseMessage Post(object editora);
        HttpResponseMessage Get(int? idEditora = null);
        HttpResponseMessage GetById(EditoraDto editora);
        HttpResponseMessage Delete(int? idEditora = null);
        HttpResponseMessage Put(EditoraDto editora);
    }
}
