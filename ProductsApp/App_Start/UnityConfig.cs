#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion

#region Referencies
using Company.Business.Context;
using Company.Business.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
#endregion

namespace ProductsApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductBUS, ProductBUS>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}