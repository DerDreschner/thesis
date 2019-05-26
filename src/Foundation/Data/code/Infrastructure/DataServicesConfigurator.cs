using System;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Glass.Mapper.Sc.Web.WebForms;
using Microsoft.Extensions.DependencyInjection;
using Sitecore;
using Sitecore.DependencyInjection;

namespace SitecoreUrlShorter.Foundation.Data.Infrastructure {
    // ReSharper disable once UnusedMember.Global
    public class DataServicesConfigurator : IServicesConfigurator {
        public void Configure(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<ISitecoreService>(provider
                => new SitecoreService(Context.ContentDatabase ?? Context.Database));
            serviceCollection.AddTransient<IGlassHtml, GlassHtml>();
            serviceCollection.AddTransient<IRequestContext, RequestContext>();
            serviceCollection.AddTransient<IMvcContext, MvcContext>();
            serviceCollection.AddTransient<IWebFormsContext, WebFormsContext>();

            serviceCollection.AddSingleton<Func<ISitecoreService>>(_ => ()
                => ServiceLocator.ServiceProvider.GetService<ISitecoreService>());
            serviceCollection.AddSingleton<Func<IGlassHtml>>(_ => ()
                => ServiceLocator.ServiceProvider.GetService<IGlassHtml>());
            serviceCollection.AddSingleton<Func<IRequestContext>>(_ => ()
                => ServiceLocator.ServiceProvider.GetService<IRequestContext>());
            serviceCollection.AddSingleton<Func<IMvcContext>>(_ => ()
                => ServiceLocator.ServiceProvider.GetService<IMvcContext>());
            serviceCollection.AddSingleton<Func<IWebFormsContext>>(_ => ()
                => ServiceLocator.ServiceProvider.GetService<IWebFormsContext>());
        }
    }
}