using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using MVC.Biblioteca.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
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
                var resposta = _livroService.Get();
                if (!resposta.IsSuccessStatusCode)
                    return View("Erro", "Erro ao buscar livros!");

                var livro = JsonConvert.DeserializeObject<IEnumerable<LivroViewModel>>(resposta.Content.ReadAsStringAsync().Result);
                return PartialView("_Grid", livro);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        /*
            try
            {
                var resposta = _livroService.Get();
                if (!resposta.IsSuccessStatusCode)
                    return View("Erro", "Erro ao buscar livros!");

                var livro = JsonConvert.DeserializeObject<IEnumerable<LivroViewModel>>(resposta.Content.ReadAsStringAsync().Result);
                return View("_Grid", livro);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
             
             */


        [HttpGet]
        public ActionResult BuscarForm()
        {
            var livro = new LivroViewModel();
            return View("_Form", livro);
        }

        public ActionResult editarDados(int? idLivro)
        {
            try
            {
                LivroViewModel livro = new LivroViewModel();
                if (idLivro.HasValue)
                {
                    var resposta = _livroService.Get();
                    if (!resposta.IsSuccessStatusCode)
                    {
                        return View("Erro", "Erro ao buscar dados!");
                    }

                    livro = JsonConvert.DeserializeObject<LivroViewModel>(resposta.Content.ReadAsStringAsync().Result);
                }

                return View("_Form", livro);

            }
            catch (Exception ex)
            {
                return View("Erro", ex.Message);
            }

        }

        public ActionResult excluirDados(int idLivro)
        {

            try
            {
                var resposta = _livroService.Delete(idLivro);
                if (!resposta.IsSuccessStatusCode)
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

        public ActionResult Post(LivroViewModel livro)
        {
            try
            {
                var resposta = _livroService.Post(livro);
                if (!resposta.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content("Erro ao cadastrar livro");
                }
                Response.StatusCode = 200;
                return Content("Ok!");
            }
            catch (Exception ex)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 500;
                return Content("Erro", ex.Message);
            }
        }





    }
}