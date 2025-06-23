using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Controls;
using Application = Microsoft.Maui.Controls.Application;
using TabbedPage = Microsoft.Maui.Controls.TabbedPage;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Button = Microsoft.Maui.Controls.Button;

namespace MauiTeams;

public partial class MenuPrincipal : TabbedPage
{
    private bool modoEscuro = false;

    public MenuPrincipal()
    {
        InitializeComponent();

        On<Microsoft.Maui.Controls.PlatformConfiguration.Android>()
            .SetToolbarPlacement(ToolbarPlacement.Bottom);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarGames();
    }

    private void AlternarTema(object sender, EventArgs e)
    {
        if (modoEscuro)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            modoEscuro = false;
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
            modoEscuro = true;
        }
    }

    private void OnSairClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LoginPage();
    }

    private async void AbrirCadastroPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroGamePage());
    }

    private async void CarregarGames()
    {
        try
        {
            string connStr = "Server=4.228.58.52;Port=3306;Database=gamesdb;Uid=mainuser;Pwd=4218ELgb";
            List<Game> games = new();

            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT * FROM games";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                games.Add(new Game
                {
                    Id = reader.GetInt32("id"),
                    Titulo = reader.GetString("titulo"),
                    Plataforma = reader.GetString("plataforma"),
                    Nota = reader.GetInt32("nota")
                });
            }

            // Exibe os games na CollectionView da aba “Games Cadastrados”
            gamesList.ItemsSource = games;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao carregar games: {ex.Message}", "OK");
        }
    }
    private void AtualizarLista(object sender, EventArgs e)
    {
        CarregarGames();
    }
    private async void ExcluirGame(object sender, EventArgs e)
    {
        var button = sender as Button;
        int gameId = (int)button.CommandParameter;

        bool confirmar = await DisplayAlert("Excluir", "Deseja realmente excluir este game?", "Sim", "Cancelar");
        if (!confirmar) return;

        try
        {
            string connStr = "Server=4.228.58.52;Port=3306;Database=gamesdb;Uid=mainuser;Pwd=4218ELgb";

            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "DELETE FROM games WHERE id = @id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", gameId);
            cmd.ExecuteNonQuery();

            await DisplayAlert("Sucesso", "Game excluído com sucesso!", "OK");
            CarregarGames(); // Atualiza a lista
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao excluir: {ex.Message}", "OK");
        }
    }
}
