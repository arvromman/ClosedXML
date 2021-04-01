using Color = SkiaSharp.SKColor;

namespace ClosedXML.Utils
{
    internal static class ColorStringParser
    {
        public static Color ParseFromHtml(string htmlColor)
        {
            // https://github.com/ClosedXML/ClosedXML/issues/675
            // When regional settings list separator is # , the standard ColorTranslator.FromHtml fails
            return Color.Parse(htmlColor.Replace("#", ""));
        }
    }
}
