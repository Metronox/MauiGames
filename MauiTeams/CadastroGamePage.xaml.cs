using MySql.Data.MySqlClient;

namespace MauiTeams;

public partial class CadastroGamePage : ContentPage
{
    public CadastroGamePage()
    {
        InitializeComponent();
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        string titulo = tituloEntry.Text;
        string plataforma = plataformaEntry.Text;
        int.TryParse(notaEntry.Text, out int nota);

        string connStr = "Server=4.228.58.52;Port=3306;Database=gamesdb;Uid=mainuser;Pwd=4218ELgb";

        try
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "INSERT INTO games (titulo, plataforma, nota) VALUES (@titulo, @plataforma, @nota)";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@plataforma", plataforma);
            cmd.Parameters.AddWithValue("@nota", nota);
            cmd.ExecuteNonQuery();

            await DisplayAlert("Sucesso", "Game cadastrado com sucesso!", "OK");

            // Limpar campos
            tituloEntry.Text = plataformaEntry.Text = notaEntry.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao salvar: {ex.Message}", "OK");
        }
    }
}
