using BrightistRenderer.Models.Texts.Fonts;
using BrightistRenderer.Models.Texts.Layouts;
using BrightistRenderer.Texts.Fonts;
using SixLabors.ImageSharp;

namespace BrightistRenderer.Texts.Layouts
{
    internal class TextLayouterProvider
    {
        private static readonly TextLayouter?[] Layouters = new TextLayouter?[2];

        public static TextLayouter GetStoryText(FontType type, int lineCount)
        {
            int initY = lineCount <= 3 ? 179 : 179 - (lineCount - 3) * 15;

            var options = new LayoutOptions
            {
                VerticalAlignment = VerticalTextAlignment.Top,
                HorizontalAlignment = HorizontalTextAlignment.Left,
                InitPoint = new Point(16, initY),
                LineHeight = 15,
                LineWidth = -1,
                TextScale = 1f,
                TextSpacing = 1
            };

            FontData font = FontProvider.GetSmallStoryFont(type);

            return new TextLayouter(options, font);
        }

        public static TextLayouter GetPopupText(FontType type)
        {
            if (Layouters[0] != null)
                return Layouters[0]!;

            var options = new LayoutOptions
            {
                VerticalAlignment = VerticalTextAlignment.Top,
                HorizontalAlignment = HorizontalTextAlignment.Left,
                InitPoint = new Point(192, 104),
                LineHeight = 15,
                LineWidth = -1,
                TextScale = 1f,
                TextSpacing = 1
            };

            FontData font = FontProvider.GetLargePopupFont(type);

            return Layouters[0] = new TextLayouter(options, font);
        }

        public static TextLayouter GetSubPopupText(FontType type)
        {
            if (Layouters[1] != null)
                return Layouters[1]!;

            var options = new LayoutOptions
            {
                VerticalAlignment = VerticalTextAlignment.Top,
                HorizontalAlignment = HorizontalTextAlignment.Left,
                InitPoint = new Point(208, 120),
                LineHeight = 15,
                LineWidth = -1,
                TextScale = 1f,
                TextSpacing = 1
            };

            FontData font = FontProvider.GetLargePopupFont(type);

            return Layouters[1] = new TextLayouter(options, font);
        }
    }
}
