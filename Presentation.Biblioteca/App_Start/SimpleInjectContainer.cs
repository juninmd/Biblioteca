using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Presentation.Biblioteca.App_Start
{
    public static class SimpleInjectContainer
    {

        //NÃO FUNCIONA! TÁ TUDO NO GLOBAL.ASAX

       public static Container RegisterServices()
        {
            var container = new Container();

            container.Register<IAutorService, AutorService>(Lifestyle.Singleton);
            container.Register<IEditoraService, EditoraService>(Lifestyle.Singleton);
            container.Register<ILivroService, LivroService>(Lifestyle.Singleton);
            container.Verify();

            return container;
        }

    }
}