using System.Linq;
using Sitecore.Data;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly IUrlShorteningServiceEntriesFolder _entriesFolder;

        public ShortUrlRepository(ISettingsRepository settingsRepository)
        {
            _entriesFolder = settingsRepository.GetEntriesFolder();
        }

        public IUrlShorteningServiceEntry GetShortUrlEntryByShorthand(string shorthand)
        {
            return _entriesFolder.Entries.FirstOrDefault(x => x.Shorthand == shorthand);
        }

        public IUrlShorteningServiceEntry GetShortUrlEntryById(ID itemId)
        {
            return _entriesFolder.Entries.FirstOrDefault(x => x.Destination.TargetId == itemId.Guid);
        }
    }
}