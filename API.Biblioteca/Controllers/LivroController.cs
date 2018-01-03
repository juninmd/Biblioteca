using Domain.Biblioteca.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Biblioteca.Controllers
{
    public class LivroController : ApiController
    {
        private readonly ILivroRepository _livroRepository;
        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IHttpActionResult Post(LivroDto livro)
        {
            if (
                string.IsNullOrEmpty(livro.nomeLivro) || string.IsNullOrEmpty(livro.ISBN) ||
                livro.precoLivro.Equals(null) || livro.dataPubLivro.Equals(null) || livro.idAutor.Equals(null) ||
                livro.idEditora.Equals(null))
               return BadRequest("Informe os dados do livro!");

            _livroRepository.Post(livro);
             return Ok();
        }

        public IHttpActionResult Get()
        {
            return Ok(_livroRepository.Get());
        }

        public IHttpActionResult GetById(int idLivro)
        {
            return Ok(_livroRepository.GetById(idLivro));
        }

        public IHttpActionResult Delete(int idLivro)
        {
            _livroRepository.Delete(idLivro);
            return Ok();
        }

        public IHttpActionResult Put(LivroDto livro)
        {
            _livroRepository.Put(livro);
            return Ok();
        }




                
    }
}
