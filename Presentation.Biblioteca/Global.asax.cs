using API.Biblioteca.App_Start;
using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.Web;
using Repository.Biblioteca;
using Domain.Biblioteca.Editora;
using Domain.Biblioteca.Livro;
using Domain.Biblioteca.Autor.dtoAutor;
using System.Reflection;
using System.Web.Http;
using System.Net.Http;

namespace Presentation.Biblioteca
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            container.Register<IEditoraAppService, EditoraAppService>(Lifestyle.Singleton);
            container.Register<IAutorAppService, AutorAppService>(Lifestyle.Singleton);
            container.Register<ILivroAppService, LivroAppService>(Lifestyle.Singleton);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}
