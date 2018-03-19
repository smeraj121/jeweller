using jeweller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;
using Unity;

namespace jeweller.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IJewellerHandle, JewellerHandler>();
            container.RegisterType<ICustomerHandle, CustomerHandler>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}