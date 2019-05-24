using Sitecore.Pipelines.HttpRequest;
using SitecoreUrlShorter.Feature.Core.Repositories;

namespace SitecoreUrlShorter.Feature.Core.Infrastructure.Pipelines
{
    // ReSharper disable once UnusedMember.Global
    public class ShortUrlResolver : HttpRequestProcessor
    {
        private readonly ISettingsRepository _settingsRepository;

        private readonly IShortUrlRepository _shortUrlRepository;

        public ShortUrlResolver(ISettingsRepository settingsRepository,
            IShortUrlRepository shortUrlRepository)
        {
            _settingsRepository = settingsRepository;
            _shortUrlRepository = shortUrlRepository;
        }

        public override void Process(HttpRequestArgs args)
        {
            var requestDomain = args.RequestUrl.Host;
            if (!requestDomain.Equals(_settingsRepository.GetDomain())) return;

            var shorthand = args.RequestUrl.Segments[1];
            if (_shortUrlRepository.GetShortUrlEntryByShorthand(shorthand) == null) return;
        }
    }
}