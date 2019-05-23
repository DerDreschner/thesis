using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls.Ribbons;

namespace SitecoreUrlShorter.Feature.UserInterface.Panels
{
    // ReSharper disable once UnusedMember.Global
    public class GenerateUrlPanel : RibbonPanel
    {

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public override void Render(HtmlTextWriter output, Ribbon ribbon, Item button, CommandContext context)
        {
            var htmlOutput = string.Empty;

            htmlOutput += "<div style='line-height:40px'><button style='vertical-align: middle;' onclick='javascript:return scForm.invoke('contenteditor:home', event)'>Generate new URL</button></div>";

            output.Write(htmlOutput);
        }
    }
}