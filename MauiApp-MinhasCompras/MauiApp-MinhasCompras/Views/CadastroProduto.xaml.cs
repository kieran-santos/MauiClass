using MauiApp_MinhasCompras.Models;

namespace MauiApp_MinhasCompras.Views;

public partial class CadastroProduto : ContentPage
{
	public CadastroProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto? produto_anexado = BindingContext as Produto;

			Produto p = new()
			{
				Descricao = txt_descricao.Text,
				Preco = Convert.ToDouble(txt_preco.Text),
				Quantidade = Convert.ToDouble(txt_quantidade.Text)
			};

			if (produto_anexado == null)
			{
				await App.Db.Insert(p);
			}
			else
			{
				p.Id = produto_anexado.Id;
				await App.Db.Update(p);
			}

			await App.Db.Insert(p);
			await DisplayAlertAsync("Sucesso!", "Dados Gravados!", "Ok");
			await Navigation.PopAsync();
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Ops", ex.Message, "Ok");
		}
    }
}