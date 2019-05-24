using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    public class GenerateUrlPanel : RibbonPanel
    {
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public override void Render(HtmlTextWriter output, Ribbon ribbon, Item button, CommandContext context)
        {
            var shortUrlRepository = ServiceLocator.ServiceProvider.GetService<IShortUrlRepository>();

            if (shortUrlRepository.GetShortUrlEntryById(context.Items[0].ID) != null)
            {
                return;
            }

            var htmlOutput = string.Empty;

            var containsLayout = context.Items.Select(contextItem => string.IsNullOrEmpty(contextItem.Fields[Sitecore.FieldIDs.LayoutField].Value)).FirstOrDefault();


            htmlOutput +=
                "<div class='verticallyCentered'><button class='generateUrlButton' onclick=\"return scForm.invoke('contenteditor:home', event)\"" + (containsLayout ? "disabled" : string.Empty) + ">Generate new URL</button></div>";

            output.Write(htmlOutput);
        }
    }
}