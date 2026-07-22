using BrightistRenderer.Texts.Fonts;

namespace BrightistRenderer.Models.Texts.Fonts
{
    internal class FontData
    {
        public int MaxHeight { get; set; }
        public ushort FallbackCharacter { get; set; }
        public required IGlyphProvider Glyphs { get; set; }
    }
}
