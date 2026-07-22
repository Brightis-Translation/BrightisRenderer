using BrightistRenderer.Models.Texts.Fonts.Bios;
using BrightistRenderer.Models.Texts.Fonts.Glyphs;
using BrightistRenderer.Texts.Characters;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace BrightistRenderer.Texts.Fonts.Bios.Glyphs
{
    internal abstract class BiosGlyphProvider : IGlyphProvider
    {
        private readonly Dictionary<ushort, byte[]> _glyphLookup = new();
        private readonly Dictionary<ushort, GlyphData> _glyphCache = new();

        public BiosGlyphProvider(BiosFontGlyphStruct[] glyphsData)
        {
            foreach (BiosFontGlyphStruct glyphData in glyphsData)
            {
                if (_glyphLookup.ContainsKey(glyphData.code))
                    continue;

                _glyphLookup[glyphData.code] = glyphData.data;
            }
        }

        public GlyphData? Get(ushort code, Rgb24 textColor)
        {
            ushort mappedCode = Ascii2SjisCharacterMapping.Map(code);

            if (_glyphCache.TryGetValue(mappedCode, out GlyphData? cachedGlyph))
                return cachedGlyph;

            Image<Rgba32> glyph = CreateGlyph(mappedCode);
            if (_glyphLookup.TryGetValue(mappedCode, out byte[]? glyphData))
                DrawGlyph(mappedCode, glyph, glyphData, textColor);

            if (mappedCode is not 0x8140 && glyphData == null)
                return null;

            return _glyphCache[mappedCode] = new GlyphData
            {
                CodePoint = code,
                Glyph = glyph,
                CharacterDescription = GetCharacterDescription(code),
                GlyphDescription = GetGlyphDescription(code)
            };
        }

        public CharacterDescriptionData? GetCharacterDescription(ushort code)
        {
            ushort mappedCode = Ascii2SjisCharacterMapping.Map(code);

            if (_glyphCache.TryGetValue(mappedCode, out GlyphData? cachedGlyph))
                return cachedGlyph.CharacterDescription;

            if (!_glyphLookup.ContainsKey(mappedCode) && mappedCode is not 0x8140)
                return null;

            return CreateCharacterDescription(mappedCode);
        }

        public GlyphDescriptionData? GetGlyphDescription(ushort code)
        {
            ushort mappedCode = Ascii2SjisCharacterMapping.Map(code);

            if (_glyphCache.TryGetValue(mappedCode, out GlyphData? cachedGlyph))
                return cachedGlyph.GlyphDescription;

            if (!_glyphLookup.ContainsKey(mappedCode) && mappedCode is not 0x8140)
                return null;

            return CreateGlyphDescription(mappedCode);
        }

        protected abstract CharacterDescriptionData CreateCharacterDescription(ushort code);
        protected abstract GlyphDescriptionData CreateGlyphDescription(ushort code);

        protected abstract Image<Rgba32> CreateGlyph(ushort code);

        protected abstract void DrawGlyph(ushort code, Image<Rgba32> glyph, byte[] data, Rgb24 textColor);
    }
}
