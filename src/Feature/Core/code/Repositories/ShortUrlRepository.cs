using System.Linq;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly IUrlShorteningServiceDataFolder _dataFolder;

        public ShortUrlRepository(IDataFolderRepository dataFolderRepository)
        {
            _dataFolder = dataFolderRepository.GetDataFolder();
        }

        public IUrlShorteningServiceEntry GetShortUrlEntryByShorthand(string shorthand)
        {
            return _dataFolder.EntriesFolder.Entries.First(x => x.Shorthand == shorthand);
        }

        public IUrlShorteningServiceEntry GetShortUrlEntryByDestination(string destination)
        {
            return _dataFolder.EntriesFolder.Entries.First(x => x.Destination.Url == destination);
        }
    }
}