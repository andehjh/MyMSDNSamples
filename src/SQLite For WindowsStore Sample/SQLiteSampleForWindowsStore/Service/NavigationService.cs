namespace SQLiteSampleForWindowsStore.Service
{
    using System;

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// Defines the NavigationService type.
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// The frame
        /// </summary>
        private Frame _mainFrame;

        /// <summary>
        /// Occurs when [navigating].
        /// </summary>
        public event NavigatingCancelEventHandler Navigating;

        /// <summary>
        /// Gets a value indicating whether this instance can go back.
        /// </summary>
        /// <value><c>true</c> if this instance can go back; otherwise, <c>false</c>.</value>
        public bool CanGoBack
        {
            get
            {
                return this.EnsureMainFrame() && this._mainFrame.CanGoBack;
            }
        }

        /// <summary>
        /// Gets the current source.
        /// </summary>
        /// <value>The current source.</value>
        public object CurrentSource
        {
            get
            {
                if (this.EnsureMainFrame())
                {
                    return this._mainFrame.Content;
                }

                return null;
            }
        }

        /// <summary>
        /// Goes the back.
        /// </summary>
        public void GoBack()
        {
            if (this.EnsureMainFrame() && this._mainFrame.CanGoBack)
            {
                this._mainFrame.GoBack();
            }
        }

        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if navigate to type page; otherwise, <c>false</c>.</returns>
        public bool NavigateTo(Type type)
        {
            if (this.EnsureMainFrame())
            {
                return this._mainFrame.Navigate(type);
            }

            return false;
        }

        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>If navigate to</returns>
        public bool NavigateTo(Type type, object parameter)
        {
            if (this.EnsureMainFrame())
            {
                return this._mainFrame.Navigate(type, parameter);
            }

            return false;
        }

        /// <summary>
        /// Ensures the main frame.
        /// </summary>
        /// <returns><c>true</c> if main frame is not null; otherwise, <c>false</c>.</returns>
        private bool EnsureMainFrame()
        {
            if (this._mainFrame != null)
            {
                return true;
            }

            this._mainFrame = Windows.UI.Xaml.Window.Current.Content as Frame;

            if (this._mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                this._mainFrame.Navigating += (s, e) =>
                {
                    var eventHandler = this.Navigating;

                    if (eventHandler != null)
                    {
                        eventHandler(s, e);
                    }
                };

                return true;
            }

            return false;
        }
    }
}
