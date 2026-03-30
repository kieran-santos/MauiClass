namespace HotelMaui.Views;

public partial class HospedagemContratada : ContentPage
{
	public HospedagemContratada()
	{
		InitializeComponent();
	}

    private async void Button_Clicked_Avancar(object sender, EventArgs e)
    {
        Cadastro cadastro = new();

        //Navegando de tela, indo para a tela criada anteriormente (linha 82)
        await Navigation.PushAsync(cadastro);
    }

    private void Button_Clicked_Voltar(object sender, EventArgs e)
    {

    }
}