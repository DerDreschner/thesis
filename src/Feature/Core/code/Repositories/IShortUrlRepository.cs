using System;
using Sitecore.Data;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories {
    public interface IShortUrlRepository {
        UrlShorteningServiceEntry GetShortUrlEntryByShorthand(string shorthand);

        UrlShorteningServiceEntry GetShortUrlEntryById(ID itemId);

        void AddShortUrl(Guid destination);
    }
}