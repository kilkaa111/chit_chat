using API.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Desktop;

public partial class RoomWindow : Window
{
    public RoomWindow(int Id)
    {   
        InitializeComponent();

        UpdateChats(Id);
    }

    public async void UpdateChats(int Id)
    {
        var chat = await Api.GetChatroom(Id);

        Messages.Text = "";
        foreach (var message in chat.Chatmessages)
        {
            Messages.Text += $"[{message.Date}] {message.SenderId}: {message.Message}\n";
        }

        memberstext.Text = "";
        foreach (var employee in chat.Employees)
        {
            memberstext.Text += $"[{employee.EmployeeId}]\n";
        }
    }
}