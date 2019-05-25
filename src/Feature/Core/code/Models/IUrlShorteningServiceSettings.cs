using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using JetBrains.Annotations;

namespace SitecoreUrlShorter.Feature.Core.Models {
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceSettings.Id)]
    public interface IUrlShorteningServiceSettings {
        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.ShorthandLength)]
        int ShorthandLength { get; [UsedImplicitly] set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.ShorthandPattern)]
        string ShorthandPattern { get; [UsedImplicitly] set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.Domain)]
        string Domain { get; [UsedImplicitly] set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.FallbackUrl)]
        Link FallbackUrl { get; [UsedImplicitly] set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceSettings.Fields.Folder)]
        [SitecoreLinked]
        IUrlShorteningServiceEntriesFolder EntriesFolder { get; [UsedImplicitly] set; }
    }
}