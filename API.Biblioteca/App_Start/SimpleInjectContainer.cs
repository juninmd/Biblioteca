using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using Domain.Biblioteca.Editora;
using Domain.Biblioteca.Livro;
using Repository.Biblioteca;
using SimpleInjector;
using System.Web.Http;

namespace API.Biblioteca.App_Start
{
    public static class SimpleInjectContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            container.Register<IEditoraAppService, EditoraAppService>();
            container.Register<IAutorAppService, AutorAppService>();
            container.Register<ILivroAppService, LivroAppService>();
            container.Register<IEditoraRepository, EditoraRepository>();
            container.Register<Domain.Biblioteca.Autor.dtoAutor.IAutorRepository, AutorRepository>();
            container.Register<ILivroRepository, LivroRepository>();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();



            return container;
        }
    }
}