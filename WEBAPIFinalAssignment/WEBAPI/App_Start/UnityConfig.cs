using System.Web.Http;
using Unity;
using Unity.WebApi;
using WEBAPI.BAL;
using WEBAPI.BAL.Helper;
using WEBAPI.BAL.Interface;

namespace WEBAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IhotelManagement, hotelManagement>();
            container.AddNewExtension<UnityRepositoryHelper>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}