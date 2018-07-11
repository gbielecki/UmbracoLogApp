using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using umbraco.presentation;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace UmbracoLogApp
{
    public class Application : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var builder = new ContainerBuilder();

            // Register umbraco context, mvc controllers and api controllers
            builder.Register(c => Umbraco.Web.UmbracoContext.Current).AsSelf();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(Application).Assembly);
            //builder.RegisterApiControllers(typeof(Lecoati.LeBlender.Extension.Helper).Assembly);
            //builder.RegisterApiControllers(typeof(Umbraco.Forms.Web.Trees.FormTreeController).Assembly);
            //builder.RegisterInstance(applicationContext.DatabaseContext.Database).As<Database>();
            //builder.RegisterInstance(applicationContext.Services.MemberTypeService).As<IMemberTypeService>();
            builder.RegisterInstance(applicationContext.Services.MemberService).As<IMemberService>();
            //builder.RegisterInstance(applicationContext.Services.MediaService).As<IMediaService>();

            var logic = typeof(Application).Assembly;

            builder.RegisterAssemblyTypes(logic)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}