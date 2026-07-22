using ImGui.Forms.Localization;

namespace BrightistRenderer.UI.Localizations
{
    internal static class StringResourceProvider
    {
        public static LocalizedString FormTitleCaption() =>
            LocalizedString.FromId("Form.Title.Caption");

        public static LocalizedString FormLoadingCaption() =>
            LocalizedString.FromId("Form.Loading.Caption");

        public static LocalizedString UnsavedChangesCaption() =>
            LocalizedString.FromId("Form.Close.UnsavedChanges.Caption");
        public static LocalizedString UnsavedChangesText() =>
            LocalizedString.FromId("Form.Close.UnsavedChanges.Text");

        public static LocalizedString MenuMetricsCaption() =>
            LocalizedString.FromId("Menu.Metrics.Caption");
        public static LocalizedString MenSettingsCaption() =>
            LocalizedString.FromId("Menu.Settings.Caption");

        public static LocalizedString MenuMetricsStoryCaption() =>
            LocalizedString.FromId("Menu.Metrics.Story.Caption");
        public static LocalizedString MenuMetricsPopupCaption() =>
            LocalizedString.FromId("Menu.Metrics.Popup.Caption");

        public static LocalizedString MenuSettingsFontTypeCaption() =>
            LocalizedString.FromId("Menu.Settings.FontType.Caption");
        public static LocalizedString MenuSettingsFontTypeBiosCaption() =>
            LocalizedString.FromId("Menu.Settings.FontType.Bios.Caption");
        public static LocalizedString MenuSettingsFontTypeKay1Caption() =>
            LocalizedString.FromId("Menu.Settings.FontType.Kay1.Caption");
        public static LocalizedString MenuSettingsFontTypeKay4Caption() =>
            LocalizedString.FromId("Menu.Settings.FontType.Kay4.Caption");

        public static LocalizedString DialogStoryMetricCaption() =>
            LocalizedString.FromId("Dialog.Metrics.Story.Caption");
        public static LocalizedString DialogPopupMetricCaption() =>
            LocalizedString.FromId("Dialog.Metrics.Popup.Caption");
        public static LocalizedString MetricsLoadingCaption() =>
            LocalizedString.FromId("Dialog.Metrics.Loading.Caption");
    }
}
