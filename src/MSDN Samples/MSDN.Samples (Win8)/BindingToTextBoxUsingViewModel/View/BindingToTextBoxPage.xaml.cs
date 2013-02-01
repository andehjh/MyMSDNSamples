namespace MSDN.Samples.BindingToTextBoxUsingViewModel.View
{
    using MSDN.Samples.BindingToTextBoxUsingViewModel.ViewModel;

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BindingToTextBoxPage : Page
    {
        public BindingToTextBoxPage()
        {
            this.InitializeComponent();
            DataContext = new BindingToTextBoxViewModel();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
