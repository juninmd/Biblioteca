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
using Repository.Biblioteca;
using Domain.Biblioteca.Editora;
using Domain.Biblioteca.Livro;

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

            container.Register<IEditoraService, EditoraService>(Lifestyle.Singleton);
            container.Register<IAutorService, AutorService>(Lifestyle.Singleton);
            container.Register<ILivroService, LivroService>(Lifestyle.Singleton);
            container.Verify();
        
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}
