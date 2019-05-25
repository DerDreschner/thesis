using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls.Ribbons;
using SitecoreUrlShorter.Feature.Core.Repositories;

namespace SitecoreUrlShorter.Feature.UserInterface.Panels
{
    // ReSharper disable once UnusedMember.Global
    public class ShowUrlPanel : RibbonPanel
    {

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public override void Render(HtmlTextWriter output, Ribbon ribbon, Item button, CommandContext context)
        {
            try
            {

                var shortUrlRepository = ServiceLocator.ServiceProvider.GetService<IShortUrlRepository>();

                var shortUrl = shortUrlRepository.GetShortUrlEntryById(context.Items[0].ID);

                if (shortUrl == null)
                {
                    return;
                }

                var settingsRepository = ServiceLocator.ServiceProvider.GetService<ISettingsRepository>();

                var domain = settingsRepository.GetDomain();

                var htmlOutput = string.Empty;

                htmlOutput +=
                    $"<div class='verticallyCentered displayFlex'><input type='text' value='{domain}/{shortUrl.Shorthand}' size='27' id='shortUrl' class='showUrlOutput' readonly><button class='copyShortUrlButton' onclick=\"return copyToClipboard('shortUrl')\"></button></div>";

                output.Write(htmlOutput);
            }
            catch
            {
                // ignored
            }
        }
    }
}