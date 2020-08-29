namespace FriendOrganizer.UI.View.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowDialog(string text, string title);
    }
}