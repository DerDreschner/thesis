using Sitecore.Pipelines.HttpRequest;
using SitecoreUrlShorter.Feature.Core.Repositories;

namespace SitecoreUrlShorter.Feature.Core.Infrastructure.Pipelines {
    // ReSharper disable once UnusedMember.Global
    public class ShortUrlResolver : HttpRequestProcessor {
        private readonly ISettingsRepository _settingsRepository;

        private readonly IShortUrlRepository _shortUrlRepository;

        public ShortUrlResolver(ISettingsRepository settingsRepository, IShortUrlRepository shortUrlRepository) {
            _settingsRepository = settingsRepository;
            _shortUrlRepository = shortUrlRepository;
        }

        public override void Process(HttpRequestArgs args) {
            if (!ShouldRun(args)) {
                return;
            }

            var requestDomain = args.RequestUrl.AbsoluteUri;
            var serviceDomain = _settingsRepository.GetDomain();

            if (!requestDomain.Contains(serviceDomain)) {
                return;
            }

            var shorthand = args.RequestUrl.Segments[1];
            var shortUrl = _shortUrlRepository.GetShortUrlEntryByShorthand(shorthand);

            args.HttpContext.Response.RedirectPermanent(shortUrl == null
                ? _settingsRepository.GetFallbackUrl().Url
                : shortUrl.Destination.Url);

            args.AbortPipeline();
        }

        private static bool ShouldRun(HttpRequestArgs args) {
            return args != null &&
                   !args.RequestUrl.AbsoluteUri.Contains("/sitecore/") &&
                   !args.RequestUrl.AbsoluteUri.Contains("/-/") &&
                   !args.RequestUrl.AbsoluteUri.Contains("/~/") &&
                   !args.RequestUrl.AbsoluteUri.Contains("/layout/");
        }
    }
}