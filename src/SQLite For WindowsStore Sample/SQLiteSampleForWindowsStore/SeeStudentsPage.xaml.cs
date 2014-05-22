using Windows.UI.Xaml.Navigation;

namespace SQLiteSampleForWindowsStore
{
    using SQLLiteSample.Model;
    using SQLLiteSample.ViewModel;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SeeStudentsPage 
    {
        public SeeStudentsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = (SeeStudentsViewModel)DataContext;
            if (viewModel != null)
            {
                await viewModel.LoadData(e.Parameter as University);
            }
        }
    }
}
