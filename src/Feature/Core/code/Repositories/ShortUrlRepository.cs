using System;
using System.Linq;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Web;
using Sitecore.Data;
using SitecoreUrlShorter.Feature.Core.Generators;
using SitecoreUrlShorter.Feature.Core.Models;

namespace SitecoreUrlShorter.Feature.Core.Repositories {
    public class ShortUrlRepository : IShortUrlRepository {
        private readonly IUrlShorteningServiceEntriesFolder _entriesFolder;

        private readonly IRequestContext _requestContext;

        private readonly ISettingsRepository _settingsRepository;

        private readonly IShorthandGenerator _shorthandGenerator;

        public ShortUrlRepository(
            ISettingsRepository settingsRepository,
            IRequestContext requestContext,
            IShorthandGenerator shorthandGenerator
        ) {
            _settingsRepository = settingsRepository;
            _entriesFolder = settingsRepository.GetEntriesFolder();
            _requestContext = requestContext;
            _shorthandGenerator = shorthandGenerator;
        }

        public IUrlShorteningServiceEntry GetShortUrlEntryByShorthand(string shorthand) {
            return _entriesFolder.Entries.FirstOrDefault(x => x.Shorthand == shorthand);
        }

        public IUrlShorteningServiceEntry GetShortUrlEntryById(ID itemId) {
            return _entriesFolder.Entries.FirstOrDefault(x => x.Destination.TargetId == itemId.Guid);
        }

        public void AddShortUrl(Guid destination) {
            var shorthand = _shorthandGenerator.GenerateShorthand(_settingsRepository.GetShorthandLength(),
                _settingsRepository.GetShorthandPattern());

            var createOptions = new CreateByNameOptions {
                Parent = _entriesFolder,
                Name = shorthand,
                Type = typeof(IUrlShorteningServiceEntry),
                Silent = true
            };

            var shortUrl = _requestContext.SitecoreService.CreateItem<IUrlShorteningServiceEntry>(createOptions);

            shortUrl.Destination = new Link {
                TargetId = destination,
                Type = LinkType.Internal
            };

            shortUrl.Shorthand = shorthand;

            _requestContext.SitecoreService.SaveItem(new SaveOptions {
                Model = shortUrl,
                Silent = true
            });
        }
    }
}