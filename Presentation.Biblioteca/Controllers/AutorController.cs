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
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Autor")]
        public ActionResult BuscarGrid()
        {
            try
            {
                var resposta = _autorService.Get();
                if (!resposta.IsSuccessStatusCode)
                {
                    return View("Erro", "Erro ao buscar autores!");
                }
                var autor = JsonConvert.DeserializeObject<IEnumerable<AutorViewModel>>(resposta.Content.ReadAsStringAsync().Result);

                return View("_Grid", autor);
            }
            catch (Exception ex)
            {
                return View("Erro", ex.Message);
            }
        }

        /*

            try
            {
                var resposta = _autorService.Get();
                if (!resposta.IsSuccessStatusCode)
                {
                    return View("Erro", "Erro ao buscar autores!");
                }
                var autor = JsonConvert.DeserializeObject<IEnumerable<AutorViewModel>>(resposta.Content.ReadAsStringAsync().Result);

                return View("_Grid", autor);
                }
                catch (Exception ex)
                {
                    return View("Erro", ex.Message);
                }
                */

        [HttpGet]
        public ActionResult BuscarForm()
        {
            var autor = new AutorViewModel();
            return View("_Form", autor);
        }


        [HttpPut]
        public ActionResult editarDados(int? idAutor)
        {
            try
            {
                AutorViewModel autor = new AutorViewModel();
                if (idAutor.HasValue)
                {

                    var resposta = _autorService.Get(idAutor);
                    if (!resposta.IsSuccessStatusCode)
                    {
                        return View("Error", "Erro ao buscar Autor");
                    }

                    autor = JsonConvert.DeserializeObject<AutorViewModel>(resposta.Content.ReadAsStringAsync().Result);
                }

                return View("_Form", autor);
            }
            catch (Exception ex)
            {
                return View("Erro", ex.Message);
            }

        }

        [HttpDelete]
        public ActionResult excluirDados(int idAutor)
        {
            try
            {
                var resposta = _autorService.Delete(idAutor);
                if (!resposta.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content("Erro ao excluir autor!");
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
        public ActionResult Post(AutorViewModel autor)
        {
            try
            {
                var resposta = _autorService.Post(autor);
                if (!resposta.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content("Erro ao inserir Autor");
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