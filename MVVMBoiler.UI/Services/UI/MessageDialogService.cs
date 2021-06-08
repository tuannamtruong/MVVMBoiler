using System.Windows;

namespace MVVMBoiler.UI.Services.UI
{
    public enum MessageDialogResult
    {
        OK,
        Cancel
    }
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowOkCancelDialog(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK ?
                MessageDialogResult.OK : MessageDialogResult.Cancel;
        }
    }
}
