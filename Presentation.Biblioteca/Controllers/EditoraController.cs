using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using Domain.Biblioteca.Editora;
using MVC.Biblioteca.Models;
using Newtonsoft.Json;
using Presentation.Biblioteca.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
                var response = _editoraService.GetById(editora.idEditora);
                if (!response.IsSuccessStatusCode)
                    return Content("Erro", "Erro ao buscar editoras!");


                var autores = (IEnumerable)JsonConvert.DeserializeObject<IEnumerable<EditoraViewModel>>
                (response.Content.ReadAsStringAsync().Result).Where(a => a.idEditora == editora.idEditora);

                return View("_Form", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }
        //var editoras = JsonConvert.DeserializeObject<EditoraViewModel>(response.Content.ReadAsStringAsync().Result)

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


        public ActionResult ExcluirDados(int idEditora)
        {
            try
            {
                var response = _editoraService.Delete(idEditora);
                if (!response.IsSuccessStatusCode)
                    return Content("Erro ao excluir editora");

                return View("_Grid");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult PostPut(EditoraViewModel editora, int? idEditora = null)
        {
            try
            {
                var response = _editoraService.PostPut(new EditoraDto {idEditora = editora.idEditora, nomeEditora = editora.nomeEditora});
                if (!response.IsSuccessStatusCode)
                    return Content("Erro");

                return View("_Grid", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

        //[HttpPost]
        //public ActionResult Post(EditoraViewModel editora)
        //{
        //    try
        //    {
        //        var response = _editoraService.Post(new EditoraDto {nomeEditora = editora.nomeEditora});
        //        if (!response.IsSuccessStatusCode)
        //            return Content("Erro ao cadastrar editora");

        //        return View("_Grid", editora);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content("Erro", ex.Message);
        //    }
        //}


    }
}