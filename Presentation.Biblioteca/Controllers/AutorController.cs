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
        private readonly IAutorAppService _autorService;

        public AutorController(IAutorAppService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult BuscarGrid()
        {
            try
            {
                var response = _autorService.Get();
                if (!response.IsSuccessStatusCode)
                    return Content("Erro", "Erro ao buscar autores!");
                
                var autor = JsonConvert.DeserializeObject<IEnumerable<AutorViewModel>>(response.Content.ReadAsStringAsync().Result);
                return View("_Grid", autor);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

        /*
            try
            {
                var App = _autorService.Get();
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
        public PartialViewResult editarDados(int? idAutor)
        {
            try
            {
                AutorViewModel autor = new AutorViewModel();
                if (idAutor.HasValue)
                {

                    var response = _autorService.Get(idAutor);
                    if (!response.IsSuccessStatusCode)
                    {
                        return PartialView("Error", "Erro ao buscar Autor");
                    }

                    autor = JsonConvert.DeserializeObject<AutorViewModel>(response.Content.ReadAsStringAsync().Result);
                }

                return PartialView("_Form", autor);
            }
            catch (Exception ex)
            {
                return PartialView("Erro", ex.Message);
            }

        }

        [HttpDelete]
        public ActionResult excluirDados(int idAutor)
        {
            try
            {
                var response = _autorService.Delete(idAutor);
                if (!response.IsSuccessStatusCode)
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
                var response = _autorService.Post(autor);
                if (!response.IsSuccessStatusCode)
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