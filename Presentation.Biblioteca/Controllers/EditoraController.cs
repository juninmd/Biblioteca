using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using Domain.Biblioteca.Editora;
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
    public class EditoraController : Controller
    {
        public readonly IEditoraAppService _editoraService;

        public EditoraController(IEditoraAppService editoraService)
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
                var response = _editoraService.Get();
                if (!response.IsSuccessStatusCode)
                {
                    return Content("Erro", "Erro ao buscar editoras!");
                }

                var editora = JsonConvert.DeserializeObject<IEnumerable<EditoraViewModel>>(response.Content.ReadAsStringAsync().Result);
                return View("_Grid", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
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
            try
            {
                var response = _editoraService.Get();
                if (!response.IsSuccessStatusCode)
                {
                    return Content("Erro", "Erro ao buscar editoras!");
                }

                var editora = new EditoraViewModel();
                return View("_Form", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

        public ActionResult Edit(EditoraViewModel editora)
        {
            try
            {
                var response = _editoraService.Get();
                if (!response.IsSuccessStatusCode)
                {
                    return Content("Erro", "Erro ao buscar editoras!");
                }

                var editoras = (IEnumerable)JsonConvert.DeserializeObject<IEnumerable<EditoraViewModel>>
               (response.Content.ReadAsStringAsync().Result).Where(e => e.idEditora == editora.idEditora);
                return View("_Form", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }


        [HttpPut]
        public ActionResult EditarDados(EditoraViewModel edt)
        {
            try
            {
                var response = _editoraService.Put(new EditoraDto {idEditora = edt.idEditora, nomeEditora = edt.nomeEditora});
                if (!response.IsSuccessStatusCode)
                    return Content("Erro", "Erro ao buscar dados!");

                var editora = JsonConvert.DeserializeObject<EditoraViewModel>(response.Content.ReadAsStringAsync().Result);
                return View("_Form", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult excluirDados(int idEditora)
        {
            try
            {
                var response = _editoraService.Delete(idEditora);
                if (!response.IsSuccessStatusCode)
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
                return Content(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult Post(EditoraViewModel editora)
        {
            try
            {
                var response = _editoraService.Post(editora);
                if (!response.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content("Erro ao inserir editora");
                }
                Response.StatusCode = 200;
                return View("_Grid");
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }

        }


    }
}