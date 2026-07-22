using BrightistRenderer.Models.Texts.Fonts;
using BrightistRenderer.Models.Texts.Layouts;
using BrightistRenderer.Models.Texts.Parsers;
using BrightistRenderer.Models.UI.Components;
using BrightistRenderer.Models.UI.Events.Messages;
using BrightistRenderer.Texts.Layouts;
using BrightistRenderer.Texts.Parsers;
using BrightistRenderer.Texts.Renderers;
using BrightistRenderer.Texts.Screens;
using BrightistRenderer.UI.Components.Editors;
using BrightistRenderer.UI.Events;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace BrightistRenderer.UI.Components.Previews
{
    internal class OverlayPopupPreviewComponent : OverlayPreviewComponent
    {
        private readonly TextParser _parser;
        private TextLayouter? _layouter;
        private TextLayouter? _subLayouter;
        private TextRenderer? _renderer;

        private PopupPreviewData? _previewData;

        public OverlayPopupPreviewComponent(OverlayEditorComponent parent) : base(parent)
        {
            _parser = TextParserProvider.GetDefault();

            FontType fontType = SettingsProvider.Instance.GetFontType();
            UpdateLayouters(fontType);
            UpdateRenderer(fontType);

            EventBroker.Instance.Subscribe<OverlayPopupUpdatedMessage>(ProcessOverlayPopupUpdated);
            EventBroker.Instance.Subscribe<OverlayPopupChangedMessage>(ProcessOverlayPopupChanged);
            EventBroker.Instance.Subscribe<FontTypeChangedMessage>(ProcessFontTypeChanged);
        }

        protected override int GetMaxCount() => 1;

        protected override Image<Rgba32>? RenderImage()
        {
            if (_previewData == null)
                return null;

            if (_layouter == null || _subLayouter == null || _renderer == null)
                return null;

            Image<Rgba32> result = ScreenProvider.GetPopupText();

            IList<CharacterData> popupCharacters = _parser.Parse(_previewData.PopupSheetData.TranslatedText);
            IList<CharacterData> subPopupCharacters = _parser.Parse(_previewData.SubPopupSheetData.TranslatedText);

            TextLayoutData popupLayout = _layouter.Create(popupCharacters, result.Size);
            TextLayoutData subPopupLayout = _subLayouter.Create(subPopupCharacters, result.Size);

            _renderer.Render(result, popupLayout);
            _renderer.Render(result, subPopupLayout);

            return result;
        }

        protected override void RaiseStoryIndexUpdated(int index)
        {
            // HINT: Popups don't update index
        }

        private void ProcessOverlayPopupUpdated(OverlayPopupUpdatedMessage message)
        {
            if (message.Target != Parent)
                return;

            _previewData = message.PreviewData;

            UpdateIndex(0);
            UpdatePreview();
        }

        private void ProcessOverlayPopupChanged(OverlayPopupChangedMessage message)
        {
            if (_previewData == null ||
                _previewData.ActiveSheetData.OverlayIndex != message.PreviewData.ActiveSheetData.OverlayIndex ||
                _previewData.ActiveSheetData.Offset != message.PreviewData.ActiveSheetData.Offset)
                return;

            _previewData = message.PreviewData;

            UpdatePreview();
        }

        private void ProcessFontTypeChanged(FontTypeChangedMessage message)
        {
            UpdateLayouters(message.Type);
            UpdateRenderer(message.Type);

            UpdatePreview();
        }

        private void UpdateLayouters(FontType type)
        {
            _layouter = TextLayouterProvider.GetPopupText(type);
            _subLayouter = TextLayouterProvider.GetSubPopupText(type);
        }

        private void UpdateRenderer(FontType type)
        {
            _renderer = TextRendererProvider.GetPopupText(type);
        }
    }
}
