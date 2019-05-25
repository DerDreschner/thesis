using System;
using Sitecore.Data;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories {
    public interface IShortUrlRepository {
        IUrlShorteningServiceEntry GetShortUrlEntryByShorthand(string shorthand);

        IUrlShorteningServiceEntry GetShortUrlEntryById(ID itemId);

        void AddShortUrl(Guid destination);
    }
}