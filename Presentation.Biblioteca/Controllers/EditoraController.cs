﻿using Application.Biblioteca.Interfaces;
using Domain.Biblioteca.Editora;
using Newtonsoft.Json;
using Presentation.Biblioteca.Models;
using System;
using System.Collections.Generic;
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

        //Apenas para trazer a view com os dados para editar
        public ActionResult Edit(EditoraViewModel editora)
        {
            try
            {
                var response = _editoraService.GetById(editora.idEditora);
                if (!response.IsSuccessStatusCode)
                    return Content("Erro", "Erro ao buscar editoras!");


                //JavaScriptSerializer serializador = new JavaScriptSerializer();
                //dynamic editoras = (EditoraViewModel)serializador.Deserialize(response.Content.ReadAsStringAsync().Result, typeof(EditoraViewModel));
                //serializador.ConvertToType<EditoraViewModel>(editoras);

                //dynamic editorass = JsonConvert.DeserializeObject<List<EditoraViewModel>>(response.Content.ReadAsStringAsync().Result);

                return View("_Form", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }
        //var editoras = JsonConvert.DeserializeObject<EditoraViewModel>(response.Content.ReadAsStringAsync().Result)

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

        //Insere e Edita
        [HttpPost]
        public ActionResult Post(EditoraViewModel editora)
        {
            try
            {
                var response = _editoraService.Post(new EditoraDto {idEditora = editora.idEditora, nomeEditora = editora.nomeEditora });
                if (!response.IsSuccessStatusCode)
                    return Content("Erro ao cadastrar editora");

                return View("_Grid", editora);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }
    }

}