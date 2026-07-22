using BrightistRenderer.Models.Texts.Fonts;
using BrightistRenderer.Texts.Fonts.Bios;
using BrightistRenderer.Texts.Fonts.Kay1;
using BrightistRenderer.Texts.Fonts.Kay4;

namespace BrightistRenderer.Texts.Fonts
{
    internal class FontProvider
    {
        private static readonly Dictionary<FontType, FontData?[]> Fonts = new();

        public static FontData GetLargePopupFont(FontType type)
        {
            FontData?[] fonts = GetFont(type);

            return fonts[0] ??= type switch
            {
                FontType.Bios => BiosFontProvider.CreateLargePopupFont(),
                FontType.Kay1 => Kay1FontProvider.CreateLargePopupFont(),
                FontType.Kay4 => Kay4FontProvider.CreateLargePopupFont(),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        public static FontData GetSmallPopupFont(FontType type)
        {
            FontData?[] fonts = GetFont(type);

            return fonts[1] ??= type switch
            {
                FontType.Bios => BiosFontProvider.CreateSmallPopupFont(),
                FontType.Kay1 => Kay1FontProvider.CreateSmallPopupFont(),
                FontType.Kay4 => Kay4FontProvider.CreateSmallPopupFont(),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        public static FontData GetSmallStoryFont(FontType type)
        {
            FontData?[] fonts = GetFont(type);

            return fonts[2] ??= type switch
            {
                FontType.Bios => BiosFontProvider.CreateSmallStoryFont(),
                FontType.Kay1 => Kay1FontProvider.CreateSmallStoryFont(),
                FontType.Kay4 => Kay4FontProvider.CreateSmallStoryFont(),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        private static FontData?[] GetFont(FontType type)
        {
            if (!Fonts.TryGetValue(type, out FontData?[]? fonts))
                Fonts[type] = fonts = new FontData?[3];

            return fonts;
        }
    }
}
