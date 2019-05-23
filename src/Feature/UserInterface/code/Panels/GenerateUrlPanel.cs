using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.UI;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls.Ribbons;

namespace SitecoreUrlShorter.Feature.UserInterface.Panels
{
    // ReSharper disable once UnusedMember.Global
    public class GenerateUrlPanel : RibbonPanel
    {
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public void Render(HtmlTextWriter output, Ribbon ribbon, Item button, CommandContext context)
        {
            var htmlOutput = string.Empty;

            var containsLayout = context.Items.Select(contextItem => string.IsNullOrEmpty(contextItem.Fields[Sitecore.FieldIDs.LayoutField].Value)).FirstOrDefault();


            htmlOutput +=
                "<div style='line-height:40px'><button style='vertical-align: middle;' onclick=\"return scForm.invoke('contenteditor:home', event)\"" + (containsLayout ? "disabled" : string.Empty) + ">Generate new URL</button></div>";

            output.Write(htmlOutput);
        }
    }
}