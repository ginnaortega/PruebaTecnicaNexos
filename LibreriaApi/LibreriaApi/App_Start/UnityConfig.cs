using LibreriaApi.Business;
using LibreriaApi.Interfaces;
using LibreriaApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace LibreriaApi.App_Start
{
    public static class UnityConfig
    {
        /// <summary>
        /// Registra las inyecciones de dependencia.
        /// </summary>
        /// <param name="unityContainer"></param>
        public static void RegisterComponents(IUnityContainer unityContainer)
        {
            var container = unityContainer ?? Container;
            Container.RegisterType<IRepositorioGenero, RepositorioGenero>();
            Container.RegisterType<IRepositorioAutor, RepositorioAutor>();
            Container.RegisterType<IRepositorioEditorial, RepositorioEditorial>();
            Container.RegisterType<IRepositorioLibro, RepositorioLibro>();
            Container.RegisterType<IRegistroLibro, RegistroLibro>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Container);
        }

        private static Lazy<IUnityContainer> _container =
            new Lazy<IUnityContainer>(() =>
           {
               var unityContainer = new UnityContainer();
               return unityContainer;
           });
        public static IUnityContainer Container => _container.Value;
    }
}