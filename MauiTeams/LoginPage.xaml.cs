using Microsoft.Maui.Controls;
using Application = Microsoft.Maui.Controls.Application;
using TabbedPage = Microsoft.Maui.Controls.TabbedPage;

namespace MauiTeams;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnEntrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(usuarioEntry.Text) || string.IsNullOrWhiteSpace(senhaEntry.Text))
        {
            DisplayAlert("Erro", "Por favor, preencha o usuário e a senha.", "OK");
            return;
        }

        Application.Current.MainPage = new NavigationPage(new MenuPrincipal());
    }
}
