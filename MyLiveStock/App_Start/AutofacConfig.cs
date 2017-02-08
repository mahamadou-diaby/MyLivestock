using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using MyLiveStock.Controllers;
using MyLiveStock.DataContrats;
using MyLiveStock.DataAccess;
using MyLiveStock.Service;
using MyliveStock.core;

namespace MyLiveStock.App_Start
{
    public class AutofacConfig
    {
        public static void SetContainer()
        {
            var builder = new ContainerBuilder();

            // Register controller
            builder.RegisterType<HomeController>().InstancePerDependency().PropertiesAutowired();
            builder.RegisterType<LayoutController>().InstancePerDependency().PropertiesAutowired();
            builder.RegisterType<RabbitController>().InstancePerDependency().PropertiesAutowired();
            builder.RegisterType<ProgrammeController>().InstancePerDependency().PropertiesAutowired();
            builder.RegisterType<ComptabiliteController>().InstancePerDependency().PropertiesAutowired();
            builder.RegisterType<UserController>().InstancePerDependency().PropertiesAutowired();
            builder.RegisterType<AccountController>().InstancePerDependency().PropertiesAutowired();

            builder.RegisterType<Repository>().As<IRepository>().PropertiesAutowired();
            builder.RegisterType<RabbitService>().As<IRabbitService>().PropertiesAutowired();
            builder.RegisterType<TransactionService>().As<ITransactionService>().PropertiesAutowired();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>().PropertiesAutowired();
            builder.RegisterType<UserRepository>().As<IUserRepository>().PropertiesAutowired();
            builder.RegisterType<UserService>().As<IUserService>().PropertiesAutowired();
            //builder.RegisterType<DBreezeContext>().SingleInstance();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ServiceLocator.Curent.Contenair = container;
        }
    }
}