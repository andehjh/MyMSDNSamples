namespace MSDN.Samples
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the OnClick event of the ButtonChangePictureSample control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void ButtonChangePictureSample_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (ButtonChangePictureSample.View.ClickToChangePictureSample));
        }

        /// <summary>
        /// Handles the OnClick event of the ConvertingToCSVFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void ConvertingToCSVFile_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ConvertingToCSVFile.View.ConvertingToCSVFilePage));
        }

        /// <summary>
        /// Handles the OnClick event of the ChildControlWithSameParentControlSize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void ChildControlWithSameParentControlSize_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChildControlWithSameParentControlSize.ChildControlWithSameParentControlSizePage));
        }

        /// <summary>
        /// Handles the OnClick event of the UpdateAppSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void UpdateAppSettingsOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UpdateAppSettings.View.UpdateAppSettingsPage));
        }

        /// <summary>
        /// Handles the OnClick event of the BindingToTextboxUsingViewModel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void BindingToTextboxUsingViewModel_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BindingToTextBoxUsingViewModel.View.BindingToTextBoxPage));
        }
    }
}
