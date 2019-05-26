using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using JetBrains.Annotations;

namespace SitecoreUrlShorter.Feature.Core.Models {
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceEntry.Id)]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class UrlShorteningServiceEntry {
        [SitecoreId]
        [UsedImplicitly]
        public virtual Guid Id { get; set; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        public virtual string Name { get; set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceEntry.Fields.Shorthand)]
        public virtual string Shorthand { get; set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceEntry.Fields.Destination)]
        public virtual Link Destination { get; set; }
    }
}