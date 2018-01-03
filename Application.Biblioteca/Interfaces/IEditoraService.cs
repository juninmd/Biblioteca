using Domain.Biblioteca.Editora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Biblioteca.Interfaces
{
    public interface IEditoraService
    {
        HttpResponseMessage Post(object autor);
        HttpResponseMessage Get(int? idEditora = null);
        HttpResponseMessage Delete(int? idEditora = null);
        HttpResponseMessage Put(EditoraDto editora);
    }
}
