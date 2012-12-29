using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YoutubeSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Sample1Page : Page
    {
        public Sample1Page()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        /// <summary>
        /// Handles the Loaded event of the MainPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var youtubeViewModel = new YoutubeViewModel();
            DataContext = youtubeViewModel;

            webView.Height = youtubeViewModel.YoutubeItem.Height + 20;
            webView.Width = youtubeViewModel.YoutubeItem.Width + 20;
            webView.NavigateToString(youtubeViewModel.YoutubeItem.Content);
        }
    }
}
