namespace SQLiteSampleForWindowsStore.Service
{
    using System;
    using System.Threading.Tasks;

    using Windows.UI.Popups;

    /// <summary>
    /// 
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        public async Task<string> ShowAsync(string messageBoxText, string caption)
        {
            var messageDialog = new MessageDialog(messageBoxText, caption);
            var result = string.Empty;
            messageDialog.Commands.Add(new UICommand("Ok", cmd => result = "Ok"));

            await messageDialog.ShowAsync();

            return result;
        }
    }
}
