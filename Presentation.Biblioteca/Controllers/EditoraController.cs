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
    public class EditoraController : Controller
    {
        public readonly IEditoraService _editoraService;

        public EditoraController(IEditoraService editoraService)
        {
            _editoraService = editoraService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarGrid()
        {
            try
            {
                var resposta = _editoraService.Get();
                if (!resposta.IsSuccessStatusCode)
                {
                    return View("Erro", "Erro ao buscar livros!");
                }

                var editora = JsonConvert.DeserializeObject<IEnumerable<EditoraViewModel>>(resposta.Content.ReadAsStringAsync().Result);
                return View("_Grid", editora);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

        }


        /*            try
            {
                var resposta = _editoraService.Get();
                if (!resposta.IsSuccessStatusCode)
                {
                    return View("Erro", "Erro ao buscar livros!");
                }

                var editora = JsonConvert.DeserializeObject<IEnumerable<EditoraViewModel>>(resposta.Content.ReadAsStringAsync().Result);

                return PartialView("_Grid", editora);

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);

            }
            
             */


        [HttpGet]
        public ActionResult BuscarForm()
        {
            var editora = new EditoraViewModel();
            return View("_Form", editora);
        }   

        public ActionResult editarDados(int? idEditora)
        {
            try
            {
                EditoraViewModel editora = new EditoraViewModel();
                if (idEditora.HasValue)
                {

                    var resposta = _editoraService.Get(idEditora);
                    if(!resposta.IsSuccessStatusCode)
                        return View("Erro", "Erro ao buscar dados!");

                    editora = JsonConvert.DeserializeObject<EditoraViewModel>(resposta.Content.ReadAsStringAsync().Result);
                }

                return View("_Form", editora);
            }
            catch (Exception ex)
            {
                return View("Erro", ex.Message);
            }
        }

        public ActionResult excluirDados(int idEditora)
        {
            try
            {

                var resposta = _editoraService.Delete(idEditora);
                if(!resposta.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content("Erro ao excluir editora");
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

        public ActionResult Post(EditoraViewModel editora)
        {
            try
            {
                var resposta = _editoraService.Post(editora);
                if (!resposta.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content("Erro ao inserir editora");
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