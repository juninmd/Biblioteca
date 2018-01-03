using Application.Biblioteca.Interfaces;
using Application.Biblioteca.Services;
using SimpleInjector;

namespace API.Biblioteca.App_Start
{
    public static class SimpleInjectContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            
            container.Register<IEditoraService, EditoraService>(Lifestyle.Singleton);
            container.Register<IAutorService, AutorService>(Lifestyle.Singleton);
            container.Register<ILivroService, LivroService>(Lifestyle.Singleton);
            container.Verify();

            return container;
        }
    }
}