namespace MSDN.Samples.ConvertingToCSVFile.View
{
    using ViewModel;
    using Windows.UI.Xaml;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertingToCSVFilePage
    {
        public ConvertingToCSVFilePage()
        {
            InitializeComponent();
            DataContext = new ConvertingToCSVFileViewModel();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            // Use the navigation frame to return to the previous page
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }
    }
}
