using ChromiumHtmlToPdfLib;
using ChromiumHtmlToPdfLib.Enums;
using ChromiumHtmlToPdfLib.Settings;

namespace Core.Helpers.Helpers
{
    public class HtmlToPdfHelper
    {
        public static void ChromiumHtmlToPdf(string filePath, string html, PaperFormat paperFormat = PaperFormat.A4)
        {
            Converter converter = new Converter();

            var pageSettings = new PageSettings(paperFormat);
            pageSettings.MarginBottom = 0;
            pageSettings.MarginLeft = 0;
            pageSettings.MarginRight = 0;
            pageSettings.MarginTop = 0;
            pageSettings.PreferCSSPageSize = true;
            pageSettings.PrintBackground = true;

            converter.ConvertToPdf(html, filePath, pageSettings);
        }
    }
}