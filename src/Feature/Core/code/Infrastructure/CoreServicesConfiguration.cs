using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SitecoreUrlShorter.Feature.Core.Repositories;

namespace SitecoreUrlShorter.Feature.Core.Infrastructure
{
    // ReSharper disable once UnusedMember.Global
    public class CoreServicesConfiguration : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDataFolderRepository, DataFolderRepository>();
            serviceCollection.AddSingleton<ISettingsRepository, SettingsRepository>();
            serviceCollection.AddSingleton<IShortUrlRepository, ShortUrlRepository>();
        }
    }
}