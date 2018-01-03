using Domain.Biblioteca.Editora;
using Repository.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Biblioteca.Controllers
{
    public class EditoraController : ApiController
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraController(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public IHttpActionResult Post(EditoraDto editora)
        {
            if (string.IsNullOrEmpty(editora.nomeEditora))
                return BadRequest("Informar dados da editora");

            _editoraRepository.Post(editora);
            return Ok();
        }

        public IHttpActionResult Get()
        {
            return Ok(_editoraRepository.Get());
        }

        public IHttpActionResult GetById(int idEditora)
        {
            return Ok(_editoraRepository.GetById(idEditora));
        }
        
        public IHttpActionResult Delete(int idEditora)
        {
            if (idEditora.Equals(null))
                return BadRequest("Informe o ID da editora");

            _editoraRepository.Delete(idEditora);
            return Ok();
        }
        
        public IHttpActionResult Put(EditoraDto editora)
        {
            _editoraRepository.Put(editora);
            return Ok();
        }

    }
}
