using Glass.Mapper.Sc.Fields;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly IUrlShorteningServiceDataFolder _dataFolder;

        public SettingsRepository(IDataFolderRepository dataFolderRepository)
        {
            _dataFolder = dataFolderRepository.GetDataFolder();
        }

        public int GetShorthandLength()
        {
            return _dataFolder.Settings.ShorthandLength;
        }

        public string GetDomain()
        {
            return _dataFolder.Settings.Domain;
        }

        public Link GetFallbackUrl()
        {
            return _dataFolder.Settings.FallbackUrl;
        }
    }
}