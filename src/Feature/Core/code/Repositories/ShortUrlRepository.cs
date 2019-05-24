using System.Linq;
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
            return _entriesFolder.Entries.First(x => x.Shorthand == shorthand);
        }

        public IUrlShorteningServiceEntry GetShortUrlEntryByDestination(string destination)
        {
            return _entriesFolder.Entries.First(x => x.Destination.Url == destination);
        }
    }
}