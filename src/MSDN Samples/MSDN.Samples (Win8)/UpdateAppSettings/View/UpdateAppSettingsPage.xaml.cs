namespace MSDN.Samples.UpdateAppSettings.View
{
    using MSDN.Samples.UpdateAppSettings.ViewModel;

    using Windows.UI.ApplicationSettings;

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class UpdateAppSettingsPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAppSettingsPage"/> class.
        /// </summary>
        public UpdateAppSettingsPage()
        {
            this.InitializeComponent();
            DataContext = new UpdateAppSettingsViewModel();
            SettingsPane.GetForCurrentView().CommandsRequested += CommandsRequested;
        }

        /// <summary>
        /// Commandses the requested.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="SettingsPaneCommandsRequestedEventArgs" /> instance containing the event data.</param>
        private void CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(
                new SettingsCommand(
                    "settings",
                    cfSettings.Heading,
                    p =>
                    {
                        cfSettings.IsOpen = true;
                    }));
        }
    }
}
