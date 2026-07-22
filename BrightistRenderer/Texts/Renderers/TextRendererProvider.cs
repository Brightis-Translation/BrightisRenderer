using BrightistRenderer.Models.Texts.Fonts;
using BrightistRenderer.Models.Texts.Renderers;
using BrightistRenderer.Texts.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace BrightistRenderer.Texts.Renderers
{
    internal class TextRendererProvider
    {
        private static readonly TextRenderer?[] Renderers = new TextRenderer?[2];

        public static TextRenderer GetStoryText(FontType type)
        {
            if (Renderers[0] != null)
                return Renderers[0]!;

            FontData font = FontProvider.GetSmallStoryFont(type);

            var options = new RenderOptions
            {
                DrawBoundingBoxes = false,
                TextColor = new Rgb24(0x20, 0x20, 0x20),
                VisibleLines = 3
            };

            return Renderers[0] = new TextRenderer(font, options);
        }

        public static TextRenderer GetPopupText(FontType type)
        {
            if (Renderers[1] != null)
                return Renderers[1]!;

            FontData font = FontProvider.GetLargePopupFont(type);

            var options = new RenderOptions
            {
                DrawBoundingBoxes = false,
                TextColor = Color.Transparent,
                VisibleLines = 1
            };

            return Renderers[1] = new TextRenderer(font, options);
        }
    }
}
