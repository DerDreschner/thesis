using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.WebControls.Presentation;
using SitecoreUrlShorter.Feature.Core.Models;
using SitecoreUrlShorter.Feature.Core.Repositories;
using Item = Sitecore.Data.Items.Item;

namespace SitecoreUrlShorter.Feature.UserInterface.Commands
{
    public class GenerateNewUrl : Command
    {
        public override void Execute (CommandContext context)
        {
            var shortUrlRepository = ServiceLocator.ServiceProvider.GetService<IShortUrlRepository>();

            Sitecore.Context.Notifications.Disabled = true;

            shortUrlRepository.AddShortUrl(context.Items[0].ID.Guid);

            Sitecore.Context.Notifications.Disabled = false;
            Sitecore.Context.ClientPage.SendMessage(this, $"item:updated(id={context.Items[0].ID})");
        }

        public override CommandState QueryState(CommandContext context)
        {
            try
            {
                var hasLayout = HasLayout(context.Items);

                if (hasLayout)
                {
                    return CommandState.Disabled;
                }

                var hasShortUrl = ServiceLocator.ServiceProvider.GetService<IShortUrlRepository>()
                                      .GetShortUrlEntryById(context.Items[0].ID) != null;

                return hasShortUrl ? CommandState.Hidden : CommandState.Enabled;
            }
            catch
            {
                return CommandState.Disabled;
            }
        }

        private static bool HasLayout(IEnumerable<Item> items)
        {
            return items.Select(contextItem =>
                string.IsNullOrEmpty(contextItem.Fields[Sitecore.FieldIDs.LayoutField].Value)).FirstOrDefault();
        }
    }
}