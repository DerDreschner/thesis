﻿using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace SitecoreUrlShorter.Feature.Core.Models
{
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceSettings.Id)]
    public interface IUrlShorteningServiceSettings
    {
        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.ShorthandLength)]
        int ShorthandLength { get; set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.Domain)]
        string Domain { get; set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.FallbackUrl)]
        Link FallbackUrl { get; set; }
    }
}