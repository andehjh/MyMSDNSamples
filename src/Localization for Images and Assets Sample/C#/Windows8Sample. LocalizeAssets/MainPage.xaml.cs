// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows8Sample.LocalizeAssets
{
    using System;

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
         }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           this.SetImages();
        }

        /// <summary>
        /// Set images.
        /// </summary>
        private void SetImages()
        {
            var imageUriForlogo = new Uri("ms-appx:///Assets/Logo.png");
            logoImage.Source = new BitmapImage(imageUriForlogo);

            var imageUri = new Uri("ms-appx:///Resources/GeneralImage.png");
            generalImage.Source = new BitmapImage(imageUri);
        }
    }
}
