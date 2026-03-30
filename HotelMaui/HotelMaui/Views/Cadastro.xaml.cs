using HotelMaui.Models;

namespace HotelMaui.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Usuario u = new Usuario();
            u.Nome = txt_nome.Text;
            u.Email = txt_email.Text;
            u.Senha = txt_senha.Text;

            App.lista_usuarios.Add(u);

            await DisplayAlertAsync("OK", "Tá cadastrado", "OK");

            await Navigation.PushAsync(new Views.Login());

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

}