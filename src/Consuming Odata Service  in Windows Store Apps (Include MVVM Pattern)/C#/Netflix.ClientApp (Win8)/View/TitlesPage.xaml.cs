// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TitlesPage.xaml.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   An empty page that can be used on its own or navigated to within a Frame.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.View
{
    using Netflix.ClientApp.ViewModel;

    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TitlesPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitlesPage"/> class.
        /// </summary>
        public TitlesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var titlesViewModel = DataContext as TitlesViewModel;
            if (titlesViewModel != null)
            {
                await titlesViewModel.LoadDataAsync();
            }
        }
    }
}
