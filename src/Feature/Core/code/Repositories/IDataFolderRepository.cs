using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public interface IDataFolderRepository
    {
        IUrlShorteningServiceDataFolder GetDataFolder();
    }
}