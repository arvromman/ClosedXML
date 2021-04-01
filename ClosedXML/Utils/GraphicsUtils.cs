using System;
using SkiaSharp;
using Font = SkiaSharp.SKFont;

namespace ClosedXML.Utils
{
    internal static class GraphicsUtils
    {
        public static class Graphics
        {
            public static int DpiX => 1;
            public static int DpiY => 1;
        }

        public static SKRect MeasureString(string s, Font font)
        {
            var paint = new SKPaint(font);
            var bound = new SKRect();
            paint.MeasureText(s, ref bound);
            return bound;
        }
    }
}
