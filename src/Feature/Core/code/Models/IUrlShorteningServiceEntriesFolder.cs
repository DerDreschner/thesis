using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using JetBrains.Annotations;

namespace SitecoreUrlShorter.Feature.Core.Models {
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceEntriesFolder.Id)]
    public interface IUrlShorteningServiceEntriesFolder {
        [SitecoreId]
        [UsedImplicitly]
        Guid Id { get; [UsedImplicitly] set; }

        [SitecoreChildren]
        IEnumerable<IUrlShorteningServiceEntry> Entries { get; [UsedImplicitly] set; }
    }
}