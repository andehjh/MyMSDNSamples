namespace SQLiteSampleForWindowsStore.Service
{
    using System.Threading.Tasks;

    /// <summary>
    /// The message box service interface
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Shows the asynchronous.
        /// </summary>
        /// <param name="messageBoxText">The message box text.</param>
        /// <param name="caption">The caption.</param>
        /// <returns></returns>
        Task<string> ShowAsync(string messageBoxText, string caption);
    }
}
