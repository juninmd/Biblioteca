using Application.Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Biblioteca.Editora;
using System.Net.Http;

namespace Application.Biblioteca.Services
{
    public class EditoraAppService : IEditoraAppService
    {

        public HttpResponseMessage Delete(int? idEditora = null)
        {
            return BaseAppService.Delete("http://localhost:5002/api/Editora" + idEditora);
        }

        public HttpResponseMessage Get(int? idEditora = null)
        {
            return BaseAppService.Get("http://localhost:5002/api/Editora", idEditora);
        }

        public HttpResponseMessage GetById(EditoraDto editora)
        {
            return BaseAppService.GetById("http://localhost:5002/api/Editora", editora.idEditora);
        }


        public HttpResponseMessage Post(object editora)
        {
            return BaseAppService.Post("http://localhost:5002/api/Editora", editora);
        }

        public HttpResponseMessage Put(EditoraDto editora)
        {
            return BaseAppService.Put("http://localhost:5002/api/Editora", editora, editora.idEditora);
        }

    }
}
