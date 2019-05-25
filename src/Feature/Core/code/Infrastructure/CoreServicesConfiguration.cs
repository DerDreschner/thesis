using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreUrlShorter.Feature.Core.Generators;
using SitecoreUrlShorter.Feature.Core.Repositories;

namespace SitecoreUrlShorter.Feature.Core.Infrastructure
{
    // ReSharper disable once UnusedMember.Global
    public class CoreServicesConfiguration : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISettingsRepository, SettingsRepository>();
            serviceCollection.AddTransient<IShortUrlRepository, ShortUrlRepository>();
            serviceCollection.AddSingleton<IShorthandGenerator, ShorthandGenerator>();

            // see https://stackoverflow.com/a/2643442/3286787
            serviceCollection.AddSingleton<Random>();
        }
    }
}