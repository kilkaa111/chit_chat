using System;
using API.Controllers;
using API.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Desktop;

public partial class ChatWindow : Window
{
    public ChatWindow()
    {
        InitializeComponent();

        UpdateChats();
    }

    public async void UpdateChats()
    {
        var chats = await Api.GetChatrooms(1);

        ChatroomsGrid.ItemsSource = chats;
    }

    private void ChatroomsGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (ChatroomsGrid.SelectedItem is ChatroomemployeeWithLastMessage chatroom)
        {
            var roomwindow = new  RoomWindow(chatroom.Id);
            roomwindow.Show();
        }
    }
}