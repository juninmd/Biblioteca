using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Biblioteca.Controllers
{
    public class AutorController : ApiController
    {
        private readonly IAutorRepository _autorRepository;
        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public IHttpActionResult Post(AutorDto autor)
        {
            if (string.IsNullOrEmpty(autor.nomeAutor) || string.IsNullOrEmpty(autor.sobrenomeAutor))
                return BadRequest("Informar dados do autor");

            _autorRepository.Post(autor);
            return Ok();
        }

        public IHttpActionResult Get(int? id = null)
        {
            return Ok(_autorRepository.Get());
        }

        public IHttpActionResult GetById(int idAutor)
        {
            return Ok(_autorRepository.GetById(idAutor));
        }
       
        public IHttpActionResult Delete(int idAutor)
        {
            if (idAutor.Equals(null))
                return BadRequest("Informe o ID do autor");

            _autorRepository.Delete(idAutor);
            return Ok();
        }

        public IHttpActionResult Put(AutorDto autor)
        {
            _autorRepository.Put(autor);
            return Ok();
        }

    }
}