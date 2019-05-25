using System;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using JetBrains.Annotations;

namespace SitecoreUrlShorter.Feature.Core.Models {
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceEntry.Id)]
    public interface IUrlShorteningServiceEntry {
        [SitecoreId]
        [UsedImplicitly]
        Guid Id { get; set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceEntry.Fields.Shorthand)]
        string Shorthand { get; set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceEntry.Fields.Destination)]
        Link Destination { get; set; }
    }
}