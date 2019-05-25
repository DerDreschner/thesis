using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Framework.Commands;
using SitecoreUrlShorter.Feature.Core.Repositories;

namespace SitecoreUrlShorter.Feature.UserInterface.Commands {
    // ReSharper disable once UnusedMember.Global
    public class GenerateNewUrl : Command {
        public override void Execute(CommandContext context) {
            var shortUrlRepository = ServiceLocator.ServiceProvider.GetService<IShortUrlRepository>();

            Context.Notifications.Disabled = true;
            shortUrlRepository.AddShortUrl(context.Items[0].ID.Guid);
            Context.Notifications.Disabled = false;

            Context.ClientPage.SendMessage(this, $"item:updated(id={context.Items[0].ID})");
        }

        public override CommandState QueryState(CommandContext context) {
            try {
                if (HasLayout(context.Items)) {
                    return CommandState.Disabled;
                }

                var hasShortUrl = HasShortUrl(context.Items);

                return hasShortUrl ? CommandState.Hidden : CommandState.Enabled;
            } catch {
                return CommandState.Disabled;
            }
        }

        private static bool HasLayout(IEnumerable<Item> items) {
            return items.Select(contextItem => string.IsNullOrEmpty(contextItem.Fields[FieldIDs.LayoutField].Value))
                        .FirstOrDefault();
        }

        private static bool HasShortUrl(IEnumerable<Item> items) {
            return ServiceLocator.ServiceProvider.GetService<IShortUrlRepository>()
                                 .GetShortUrlEntryById(items.FirstOrDefault()?.ID) != null;
        }
    }
}