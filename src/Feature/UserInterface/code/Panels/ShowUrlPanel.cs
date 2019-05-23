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
    public class ShowUrlPanel : RibbonPanel
    {

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public override void Render(HtmlTextWriter output, Ribbon ribbon, Item button, CommandContext context)
        {
            var htmlOutput = string.Empty;

            htmlOutput += "<div style='line-height:40px;display:flex;'><input type='text' value='http://shrtsvc.local/23io3dso' size='27' id='shortUrl' style='vertical-align: middle;' disabled><input type='image' src='/temp/iconcache/office/32x32/clipboard_paste.png' onclick=\"return copyToClipboard('shortUrl')\"></div>";

            output.Write(htmlOutput);
        }
    }
}