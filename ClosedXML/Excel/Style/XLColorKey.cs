﻿using System;
using Color = SkiaSharp.SKColor;
namespace ClosedXML.Excel
{
    internal struct XLColorKey : IEquatable<XLColorKey>
    {
        public XLColorType ColorType { get; set; }

        public Color Color { get; set; }

        public int Indexed { get; set; }

        public XLThemeColor ThemeColor { get; set; }

        public double ThemeTint { get; set; }

        public override int GetHashCode()
        {
            var hashCode = -331517974;
            hashCode = hashCode * -1521134295 + (int)ColorType;
            hashCode = hashCode * -1521134295 + (ColorType == XLColorType.Indexed ? Indexed : 0);
            hashCode = hashCode * -1521134295 + (ColorType == XLColorType.Theme ? (int)ThemeColor : 0);
            hashCode = hashCode * -1521134295 + (ColorType == XLColorType.Theme ? ThemeTint.GetHashCode() : 0);
            hashCode = hashCode * -1521134295 + (ColorType == XLColorType.Color ? Color.GetHashCode() : 0);
            return hashCode;
        }

        public bool Equals(XLColorKey other)
        {
            if (ColorType == other.ColorType)
            {
                if (ColorType == XLColorType.Color)
                {
                    // .NET Color.Equals() will return false for Color.FromArgb(255, 255, 255, 255) == Color.White
                    // Therefore we compare the ToArgb() values
                    return Color.GetHashCode() == other.Color.GetHashCode();
                }
                if (ColorType == XLColorType.Theme)
                {
                    return
                        ThemeColor == other.ThemeColor
                     && Math.Abs(ThemeTint - other.ThemeTint) < XLHelper.Epsilon;
                }
                return Indexed == other.Indexed;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is XLColorKey)
                return Equals((XLColorKey)obj);
            return base.Equals(obj);
        }

        public override string ToString()
        {
            switch (ColorType)
            {
                case XLColorType.Color:
                    return Color.ToString();
                case XLColorType.Theme:
                    return $"{ThemeColor} ({ThemeTint})";
                case XLColorType.Indexed:
                    return $"Indexed: {Indexed}";
                default:
                    return base.ToString();
            }
        }

        public static bool operator ==(XLColorKey left, XLColorKey right) => left.Equals(right);

        public static bool operator !=(XLColorKey left, XLColorKey right) => !(left.Equals(right));
    }
}
