using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace SitecoreUrlShorter.Feature.Core.Models
{
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceDataFolder.Id)]
    public interface IUrlShorteningServiceDataFolder
    {
        [SitecoreChildren(TemplateId = Templates.UrlShorteningServiceSettings.Id)]
        IUrlShorteningServiceSettings Settings { get; set; }

        [SitecoreChildren(TemplateId = Templates.UrlShorteningServiceEntriesFolder.Id)]
        IUrlShorteningServiceEntriesFolder EntriesFolder { get; set; }
    }
}