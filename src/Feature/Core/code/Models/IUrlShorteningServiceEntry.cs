using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace SitecoreUrlShorter.Feature.Core.Models
{
    [SitecoreType(TemplateId = Templates.UrlShorteningServiceEntry.Id)]
    public interface IUrlShorteningServiceEntry
    {
        [SitecoreField(FieldId = Templates.UrlShorteningServiceEntry.Fields.Shorthand)]
        string Shorthand { get; set; }

        [SitecoreField(FieldId = Templates.UrlShorteningServiceEntry.Fields.Destination)]
        Link Destination { get; set; }
    }
}