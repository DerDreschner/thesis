using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace SitecoreUrlShorter.Feature.Core.Models
{
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceEntriesFolder.Id)]
    public interface IUrlShorteningServiceEntriesFolder
    {
        [SitecoreId]
        Guid Id { get; set; }

        [SitecoreChildren]
        IEnumerable<IUrlShorteningServiceEntry> Entries { get; set; }
    }
}