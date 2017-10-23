using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PozadavkyZakazniku.Repository.Mappers;
using Autofac.Integration.Mvc;
using Autofac;
using PozadavkyZakazniku.Service;
using PozadavkyZakazniku.Service.Interfaces;
using PozadavkyZakazniku.Repository;
using PozadavkyZakazniku.Repository.Interfaces;
using System.Web.Mvc;
using PozadavkyZakazniku.Web.Filters;

namespace PozadavkyZakazniku.Web.App_Start
{
    public static class ConfigAutoMapperAndIOC
    {
        public static void Configuration()
        {
            ConfigureAutofacContainer(); // IOC
            ConfigureAutomapper();
        }

        private static void ConfigureAutomapper()
        {
            // konfigurace Mapperu - ve tride MaperDbToModel je popis
            // ktery objekt se ma na co mapovat (User => UserModel)
            Mapper.Initialize(mapper =>
            {
                mapper.AddProfile<MaperDbToModel>();
            });
        }

        public static void ConfigureAutofacContainer()
        {
            // vytvorime Autofac DIContainer uchovava informace o mapovani Interface na Tridy
            var containerBuilder = new ContainerBuilder();
            // User
            containerBuilder.RegisterType<UserService>().As<IUserService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().AsImplementedInterfaces().InstancePerRequest();
            // Request
            containerBuilder.RegisterType<RequestService>().As<IRequestService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<RequestRepository>().As<IRequestRepository>().AsImplementedInterfaces().InstancePerRequest();
            // Status
            containerBuilder.RegisterType<StatusService>().As<IStatusService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<StatusRepository>().As<IStatusRepository>().AsImplementedInterfaces().InstancePerRequest();
            // Module
            containerBuilder.RegisterType<ModuleService>().As<IModuleService>().AsImplementedInterfaces().InstancePerRequest();
            containerBuilder.RegisterType<ModuleRepository>().As<IModuleRepository>().AsImplementedInterfaces().InstancePerRequest();
            

            //----------- vyresime konstruktor
            containerBuilder.Register(r => new UserService(r.Resolve<IUserRepository>())).AsImplementedInterfaces().InstancePerLifetimeScope();
            // Request
            containerBuilder.Register(r => new RequestService(r.Resolve<IRequestRepository>())).AsImplementedInterfaces().InstancePerLifetimeScope();
            // Status
            containerBuilder.Register(r => new StatusService(r.Resolve<IStatusRepository>())).AsImplementedInterfaces().InstancePerLifetimeScope();
            // Module
            containerBuilder.Register(r => new ModuleService(r.Resolve<IModuleRepository>())).AsImplementedInterfaces().InstancePerLifetimeScope();

            // registrace autentizacni tridy
            containerBuilder.Register(r => new GCAuthentication(r.Resolve<IUserService>())).AsAuthenticationFilterFor<Controller>().InstancePerLifetimeScope();

            // prekopirovat do projektu. Je potreba pro MVC
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            containerBuilder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            containerBuilder.RegisterModule<AutofacWebTypesModule>();
            containerBuilder.RegisterFilterProvider();

            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}