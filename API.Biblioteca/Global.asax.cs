using API.Biblioteca.App_Start;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace API.Biblioteca
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectContainer.RegisterServices());
        }
    }
}
