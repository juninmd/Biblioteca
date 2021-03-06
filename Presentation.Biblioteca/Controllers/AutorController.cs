﻿using Application.Biblioteca.Interfaces;
using Domain.Biblioteca.Autor;
using Newtonsoft.Json;
using Presentation.Biblioteca.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        [HttpGet]
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

        [HttpGet]
        public ActionResult BuscarForm()
        {
            try
            {
                var response = _autorService.Get();
                if (!response.IsSuccessStatusCode)
                {
                    return Content("Erro", "Erro!");
                }

                var autor = new AutorViewModel();
                return View("_Form", autor);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }

        public ActionResult Edit(AutorViewModel autor)
        {
            try
            {
                var response = _autorService.Get(autor.idAutor);
                if (!response.IsSuccessStatusCode)
                    return Content("Erro", "Erro!");
                

                var autores = (IEnumerable)JsonConvert.DeserializeObject<IEnumerable<AutorViewModel>>
                (response.Content.ReadAsStringAsync().Result).Where(a => a.idAutor == autor.idAutor);
                return View("_Form", autor);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
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
                return PartialView("Error");
            }
        }

        public ActionResult ExcluirDados(int idAutor)
        {
            try
            {
                var response = _autorService.Delete(idAutor);
                if (!response.IsSuccessStatusCode)
                    return Content("Erro ao excluir autor!");

                return View("_Grid");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(AutorViewModel autor)
        {
            try
            {
                var response = _autorService.Post(new AutorDto {idAutor = autor.idAutor, nomeAutor = autor.nomeAutor, sobrenomeAutor = autor.sobrenomeAutor});
                if (!response.IsSuccessStatusCode)
                    return Content("Erro ao inserir Autor");

                return View("_Grid", autor);
            }
            catch (Exception ex)
            {
                return Content("Erro", ex.Message);
            }
        }
    }

}