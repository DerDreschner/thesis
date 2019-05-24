using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace SitecoreUrlShorter.Feature.Core.Models
{
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceEntriesFolder.Id)]
    public interface IUrlShorteningServiceEntriesFolder
    {
        [SitecoreChildren(TemplateId = Templates.UrlShorteningServiceEntry.Id)]
        IEnumerable<IUrlShorteningServiceEntry> Entries { get; set; }
    }
}