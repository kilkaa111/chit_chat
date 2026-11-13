using System.Threading.Tasks;
using Avalonia.Controls;

namespace Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OkClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var username = Username.Text;
        var password = Password.Text;

        var employee = await Api.Loginuser(username,password);
        if (employee.Id == 0)
        {
            Close();
            return;
        }

        var chatwindow = new ChatWindow();
        chatwindow.Show();
    }

    private void CancelClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    
}