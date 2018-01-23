using Domain.Biblioteca.Autor;
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
        private readonly IAutorService _autorService;

        public AutorController(IAutorRepository autorRepository, IAutorService autorService)
        {
            _autorRepository = autorRepository;
            _autorService = autorService;
        }

        public IHttpActionResult Post(AutorDto autor)
        {
            if (string.IsNullOrEmpty(autor.nomeAutor) || string.IsNullOrEmpty(autor.sobrenomeAutor))
                return BadRequest("Informar dados do autor");

            _autorService.Post(autor);
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