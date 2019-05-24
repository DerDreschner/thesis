using System;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public interface IShortUrlRepository
    {
        IUrlShorteningServiceEntry GetShortUrlEntryByShorthand(string shorthand);

        IUrlShorteningServiceEntry GetShortUrlEntryByDestination(string destination);
    }
}