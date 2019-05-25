using System;
using System.Linq;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Configuration;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly IUrlShorteningServiceSettings _settings;

        public SettingsRepository(IMvcContext mvcContext)
        {
            var context = mvcContext.SitecoreService;

            try
            {
                _settings = context.GetItem<IUrlShorteningServiceSettings>(
                    Settings.GetSetting("SitecoreUrlShorter.Feature.Core.Settings"));
            }
            catch
            {
                // ignored
            }
        }

        public int GetShorthandLength()
        {
            return _settings.ShorthandLength;
        }

        public string GetShorthandPattern()
        {
            return _settings.ShorthandPattern;
        }

        public string GetDomain()
        {
            return _settings.Domain;
        }

        public Link GetFallbackUrl()
        {
            return _settings.FallbackUrl;
        }

        public IUrlShorteningServiceEntriesFolder GetEntriesFolder()
        {
            return _settings?.EntriesFolder;
        }
    }
}