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
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void ButtonChangePictureSample_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (ButtonChangePictureSample.View.ClickToChangePictureSample));
        }

        private void ConvertingToCSVFile_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ConvertingToCSVFile.View.ConvertingToCSVFilePage));
        }
    }
}
