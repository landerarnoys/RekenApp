using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Unity.WebApi;
using System.Data.Entity;
using Wiskunde_App.DataAccess.Repositories;
using Wiskunde_App.DataAccess.UOW;
using Wiskunde_App.Models;
using Wiskunde_App.DataAccess.Services;
using Wiskunde_App.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;
using Wiskunde_App.DataAccess.Context;

namespace Wiskunde_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, WiskundeContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUOW, UOW>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<School>, GenericRepository<School>>(new HierarchicalLifetimeManager());
            container.RegisterType<ISuperuserservice, Superuserservice>(new HierarchicalLifetimeManager());
            container.RegisterType<ISchoolRepository, SchoolRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOefeningService, OefeningService>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<Oefeningen>,GenericRepository<Oefeningen>>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<Resultaten>, GenericRepository<Resultaten>>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<Klas>, GenericRepository<Klas>>(new HierarchicalLifetimeManager());
             container.RegisterType<IGenericRepository<Leerling>, GenericRepository<Leerling>>(new HierarchicalLifetimeManager());
      
            container.RegisterType<IGenericRepository<LeerkrachtSchoolKlas>, GenericRepository<LeerkrachtSchoolKlas>>(new HierarchicalLifetimeManager());
            container.RegisterType<IKlasRepository, Klasrepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILeerlingrepository, Leerlingrepository>(new HierarchicalLifetimeManager());
            container.RegisterType<Iklasservice, Klasservice>(new HierarchicalLifetimeManager());
            container.RegisterType<ILeerlingservice, Leerlingservice>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<Leerling>, GenericRepository<Leerling>>(new HierarchicalLifetimeManager());
            //Registreren usermanagement service
            container.RegisterType<IUserManagementService, UserManagementService>(new HierarchicalLifetimeManager());
            container.RegisterType<IIdentityManagerRepository, IdentityManagerRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());

            /* Registreren userservice en userrepository */
            container.RegisterType<IGebruikersrepository, Gebruikersrepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGebruikersservice, Gebruikersservice>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<ApplicationUser>, GenericRepository<ApplicationUser>>(new HierarchicalLifetimeManager());


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}