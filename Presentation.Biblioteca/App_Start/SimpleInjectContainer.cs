using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            container.Register<IAutorAppService, AutorAppService>();
            container.Register<IEditoraAppService, EditoraAppService>();
            container.Register<ILivroAppService, LivroAppService>();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            return container;
        }
    }
}
