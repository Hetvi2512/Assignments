using System.Web.Http;
using TestingAssignment.Models;
using Unity;

using TestingAssignment.Repository;
using System.Web.Mvc;
using Unity.AspNet.WebApi;

namespace TestingAssignment
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; internal set; }

        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
          
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPassengerRepository, PassengerRepository>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}