using BrightistRenderer.Models.Texts.Fonts.Glyphs;
using SixLabors.ImageSharp.PixelFormats;

namespace BrightistRenderer.Texts.Fonts
{
    internal interface IGlyphProvider
    {
        GlyphData? Get(ushort code, Rgb24 textColor);
        CharacterDescriptionData? GetCharacterDescription(ushort code);
        GlyphDescriptionData? GetGlyphDescription(ushort code);
    }
}
