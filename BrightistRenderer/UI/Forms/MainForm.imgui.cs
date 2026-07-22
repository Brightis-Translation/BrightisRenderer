using BrightistRenderer.UI.Localizations;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using System.Numerics;
using ImGui.Forms.Controls.Menu;
using BrightistRenderer.Models.Texts.Fonts;

namespace BrightistRenderer.UI.Forms
{
    internal partial class MainForm
    {
        private MainMenuBar _mainMenu;

        private MenuBarMenu _metricsMenu;
        private MenuBarMenu _settingsMenu;

        private MenuBarButton _metricsStoryMenu;
        private MenuBarButton _metricsPopupMenu;

        private MenuBarRadio _fontTypeMenu;
        private MenuBarCheckBox _biosFontTypeMenu;
        private MenuBarCheckBox _kay1FontTypeMenu;
        private MenuBarCheckBox _kay4FontTypeMenu;

        private StackLayout _mainLayout;

        private TabControl _overlayGroupsControl;
        private Label _loadingLabel;

        private void InitializeComponent()
        {
            _metricsStoryMenu = new MenuBarButton(StringResourceProvider.MenuMetricsStoryCaption());
            _metricsPopupMenu = new MenuBarButton(StringResourceProvider.MenuMetricsPopupCaption());

            _biosFontTypeMenu = new MenuBarCheckBox(StringResourceProvider.MenuSettingsFontTypeBiosCaption());
            _kay1FontTypeMenu = new MenuBarCheckBox(StringResourceProvider.MenuSettingsFontTypeKay1Caption());
            _kay4FontTypeMenu = new MenuBarCheckBox(StringResourceProvider.MenuSettingsFontTypeKay4Caption());

            _fontTypeMenu = new MenuBarRadio(StringResourceProvider.MenuSettingsFontTypeCaption())
            {
                CheckItems =
                {
                    _biosFontTypeMenu,
                    _kay1FontTypeMenu,
                    _kay4FontTypeMenu
                }
            };

            _metricsMenu = new MenuBarMenu(StringResourceProvider.MenuMetricsCaption())
            {
                Items =
                {
                    _metricsStoryMenu,
                    _metricsPopupMenu
                }
            };

            _settingsMenu = new MenuBarMenu(StringResourceProvider.MenSettingsCaption())
            {
                Items =
                {
                    _fontTypeMenu
                }
            };

            _mainMenu = new MainMenuBar
            {
                Items =
                {
                    _metricsMenu,
                    _settingsMenu
                }
            };

            _overlayGroupsControl = new TabControl();
            _loadingLabel = new Label(StringResourceProvider.FormLoadingCaption());

            _mainLayout = new StackLayout
            {
                Alignment = Alignment.Vertical,
                Size = ImGui.Forms.Models.Size.Parent,
                ItemSpacing = 5,
                Items =
                {
                    _overlayGroupsControl,
                    _loadingLabel
                }
            };

            Content = _mainLayout;
            MenuBar = _mainMenu;

            Size = new Vector2(1500, 800);
            Title = StringResourceProvider.FormTitleCaption();

            InitializeFontType();
        }

        private void InitializeFontType()
        {
            switch (SettingsProvider.Instance.GetFontType())
            {
                case FontType.Bios:
                    _biosFontTypeMenu.Checked = true;
                    break;

                case FontType.Kay1:
                    _kay1FontTypeMenu.Checked = true;
                    break;

                case FontType.Kay4:
                    _kay4FontTypeMenu.Checked = true;
                    break;
            }
        }
    }
}
