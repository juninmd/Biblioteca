﻿using Application.Biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Biblioteca.Editora;
using System.Net.Http;

namespace Application.Biblioteca.Services
{
    public class EditoraService : IEditoraService
    {

        public HttpResponseMessage Delete(int? idEditora = null)
        {
            return BaseAppService.Delete("http://localhost:5001/Editora/Delete?id=" + idEditora);
        }

        public HttpResponseMessage Get(int? idEditora = null)
        {
            return BaseAppService.Get("http://localhost:5001/Editora/Get" + idEditora);
        }

        public HttpResponseMessage Post(object editora)
        {
            return BaseAppService.Post("http://localhost:5001/Editora/Post", editora);
        }

        public HttpResponseMessage Put(EditoraDto editora)
        {
            return BaseAppService.Put("http://localhost:5001/Editora/Put", editora, editora.idEditora);
        }

    }
}
