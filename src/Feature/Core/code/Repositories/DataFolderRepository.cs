using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Configuration;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories
{
    public class DataFolderRepository : IDataFolderRepository
    {
        private readonly IUrlShorteningServiceDataFolder _dataFolder;

        public DataFolderRepository()
        {
            var context = new MvcContext().SitecoreService;
            _dataFolder =
                context.GetItem<IUrlShorteningServiceDataFolder>(
                    Settings.GetSetting("SitecoreUrlShorter.Feature.Core.Datastore"));
        }

        public IUrlShorteningServiceDataFolder GetDataFolder()
        {
            return _dataFolder;
        }
    }
}