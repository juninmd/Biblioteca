using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using Domain.Biblioteca.Livro;
using MVC.Biblioteca.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroAppService _livroService;

        public LivroController(ILivroAppService livroService)
        {
            _livroService = livroService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarGrid()
        {
            try
            {
                var response = _livroService.Get();
                if (!response.IsSuccessStatusCode)
                    return Content("Erro", "Erro ao buscar livros!");

                var livro = JsonConvert.DeserializeObject<IEnumerable<LivroViewModel>>(response.Content.ReadAsStringAsync().Result);
                return View("_Grid", livro);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }


        [HttpGet]
        public ActionResult BuscarForm()
        {
            try
            {
                var response = _livroService.Get();
                if (!response.IsSuccessStatusCode)
                {
                    return Content("Erro", "Erro ao buscar editoras!");
                }

                var livro = new LivroViewModel();
                return View("_Form", livro);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

        public ActionResult Edit(LivroViewModel livro)
        {
            try
            {
                var response = _livroService.Get(livro.idLivro);
                if (!response.IsSuccessStatusCode)
                {
                    return Content("Erro", "Erro");
                }
                var livros = (IEnumerable)JsonConvert.DeserializeObject<IEnumerable<LivroViewModel>>
               (response.Content.ReadAsStringAsync().Result).Where(l => l.idLivro == livro.idLivro);
                return View("_Form", livro);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

        public ActionResult editarDados(int? idLivro)
        {
            try
            {
                LivroViewModel livro = new LivroViewModel();
                if (idLivro.HasValue)
                {
                    var response = _livroService.Get();
                    if (!response.IsSuccessStatusCode)
                    {
                        return View("Erro", "Erro ao buscar dados!");
                    }

                    livro = JsonConvert.DeserializeObject<LivroViewModel>(response.Content.ReadAsStringAsync().Result);
                }

                return View("_Form", livro);

            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }

        }

        public ActionResult excluirDados(int idLivro)
        {

            try
            {
                var response = _livroService.Delete(idLivro);
                if (!response.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content("Erro ao excluir livro");
                }
                Response.StatusCode = 200;
                return Content("Ok!");

            }
            catch (Exception ex)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 500;
                return Content(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult Post(LivroViewModel livro)
        {
            try
            {
                var response = _livroService.Post(
                    new LivroDto
                    {
                        nomeLivro = livro.nomeLivro, ISBN = livro.ISBN, dataPubLivro = livro.dataPubLivro,
                        precoLivro = livro.precoLivro, idAutor = livro.idAutor, idEditora = livro.idEditora
                    }
                    );
                if (!response.IsSuccessStatusCode)
                    return Content("Erro ao cadastrar livro");

                 return View("_Grid", livro);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

    }
}