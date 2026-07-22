using BrightistRenderer.Models.Texts.Fonts;
using BrightistRenderer.Models.Texts.Fonts.Bios;
using BrightistRenderer.Texts.Fonts.Bios;
using BrightistRenderer.Texts.Fonts.Bios.Glyphs;

namespace BrightistRenderer.Texts.Fonts.Kay1
{
    internal class Kay1FontProvider
    {
        private static BiosFontGlyphStruct[]? _glyphsData;

        public static FontData CreateLargePopupFont()
        {
            BiosFontGlyphStruct[] glyphsData = ReadGlyphsData();

            return new FontData
            {
                MaxHeight = 16,
                FallbackCharacter = 0x8148,
                Glyphs = new LargePopupBiosGlyphProvider(glyphsData)
            };
        }

        public static FontData CreateSmallPopupFont()
        {
            BiosFontGlyphStruct[] glyphsData = ReadGlyphsData();

            return new FontData
            {
                MaxHeight = 13,
                FallbackCharacter = 0x8148,
                Glyphs = new SmallPopupBiosGlyphProvider(glyphsData)
            };
        }

        public static FontData CreateSmallStoryFont()
        {
            BiosFontGlyphStruct[] glyphsData = ReadGlyphsData();

            return new FontData
            {
                MaxHeight = 13,
                FallbackCharacter = 0x8148,
                Glyphs = new SmallStoryBiosGlyphProvider(glyphsData)
            };
        }

        private static BiosFontGlyphStruct[] ReadGlyphsData()
        {
            if (_glyphsData != null)
                return _glyphsData;

            Stream? rawFont1 = GetFontStream("font1.raw");
            Stream? rawFont2 = GetFontStream("font2.raw");
            if (rawFont1 == null || rawFont2 == null)
                return [];

            return _glyphsData = BiosFontReader.Read(rawFont1, rawFont2);
        }

        private static Stream? GetFontStream(string resourceName)
        {
            string? applicationDirectory = Path.GetDirectoryName(Environment.ProcessPath);
            if (string.IsNullOrEmpty(applicationDirectory))
                return null;

            string resourcePath = Path.Combine(applicationDirectory, "resources", "font", "bios", resourceName);
            if (!File.Exists(resourcePath))
                return null;

            return File.OpenRead(resourcePath);
        }
    }
}
