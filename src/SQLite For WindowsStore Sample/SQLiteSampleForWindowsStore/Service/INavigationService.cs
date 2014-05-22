namespace SQLiteSampleForWindowsStore.Service
{
    using System;

    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// Defines navigation services interface
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Occurs when [navigating].
        /// </summary>
        event NavigatingCancelEventHandler Navigating;

        /// <summary>
        /// Gets a value indicating whether this instance can go back.
        /// </summary>
        /// <value><c>true</c> if this instance can go back; otherwise, <c>false</c>.</value>
        bool CanGoBack { get; }

        /// <summary>
        /// Gets the current source.
        /// </summary>
        /// <value>The current source.</value>
        object CurrentSource { get; }

        /// <summary>
        /// Goes the back.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if navigate to type page; otherwise, <c>false</c>.</returns>
        bool NavigateTo(Type type);

        /// <summary>
        /// The navigate to.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        bool NavigateTo(Type type, object parameter);
    }
}
