using AuthenticationSample.UniversalApps.Services;
using AuthenticationSample.UniversalApps.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AuthenticationSample.UniversalApps.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
#if WINDOWS_PHONE_APP
       public sealed partial class LoginView : Page, IWebAuthenticationContinuable
#else
      public sealed partial class LoginView : Page
#endif
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginView"/> class.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The on navigated to.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = (LoginViewModel)DataContext;
            viewModel.NavigationService.RemoveBackEntry();
            base.OnNavigatedTo(e);
        }

#if WINDOWS_PHONE_APP
        public void ContinueWebAuthentication(Windows.ApplicationModel.Activation.WebAuthenticationBrokerContinuationEventArgs args)
        {
            var viewModel = (LoginViewModel) DataContext;
            viewModel.Finalize(args);
        }
#endif
    }
}
