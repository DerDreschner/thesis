using System.Web.UI;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using Sitecore.StringExtensions;

namespace SitecoreUrlShorter.Feature.UserInterface.Pipelines
{
    // ReSharper disable once UnusedMember.Global
    public class AddScriptsToContentEditor
    {
        private const string JavascriptTag = "<script src=\"{0}\"></script>";
        private const string StylesheetLinkTag = "<link href=\"{0}\" rel=\"stylesheet\" />";

        // ReSharper disable once UnusedMember.Global
        public void Process(PipelineArgs args)
        {
            AddControls(JavascriptTag, "SitecoreUrlShorter.Feature.UserInterface.JavaScript");
            AddControls(StylesheetLinkTag, "SitecoreUrlShorter.Feature.UserInterface.Stylesheet");
        }

        private static void AddControls(string resourceTag, string configKey)
        {
            Assert.IsNotNullOrEmpty(configKey, "Content Editor resource config key cannot be null");

            var resource = Settings.GetSetting(configKey);

            if (string.IsNullOrEmpty(resource)) return;

            Context.Page.Page.Header.Controls.Add(new LiteralControl(resourceTag.FormatWith(resource)));
        }
    }
}