using BrightistRenderer.Models.Texts.Fonts;

namespace BrightistRenderer.Models.UI.Events.Messages
{
    internal class FontTypeChangedMessage
    {
        public FontType Type { get; }

        public FontTypeChangedMessage(FontType type)
        {
            Type = type;
        }
    }
}
