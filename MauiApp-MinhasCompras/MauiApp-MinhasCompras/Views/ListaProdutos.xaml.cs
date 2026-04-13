using System.Collections.ObjectModel;
using MauiApp_MinhasCompras.Models;

namespace MauiApp_MinhasCompras.Views;

public partial class ListaProdutos : ContentPage
{
    ObservableCollection<Produto> lista = new();

	public ListaProdutos()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = lista;

        //lst_produtos.ItemsSource = new List<Models.Produto>()
        //{
        //    new Models.Produto() {Id=1, Descricao="Maçã", Preco=10.95, Quantidade=2.40},
        //    new Models.Produto() {Id=2, Descricao="Maracujá", Preco=7.95, Quantidade=1.23},
        //    new Models.Produto() {Id=3, Descricao="Alface", Preco=8.99, Quantidade=1},
        //    new Models.Produto() {Id=4, Descricao="Banana Nanica", Preco=8.70, Quantidade=2.10},
        //    new Models.Produto() {Id=5, Descricao="Tomate", Preco=6.95, Quantidade=3.21}
        //};

    }

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();
            List<Produto> tmp = await App.Db.GetAll();
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Ok");
        }
    }

    private async void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O total é {soma:C}";
        await DisplayAlertAsync("Total", msg, "Ok");
    }

    private void ToolbarItem_Clicked_Adicionar(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.CadastroProduto());
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;
            lst_produtos.IsRefreshing = true;
            lista.Clear();
            List<Produto> tmp = await App.Db.Search(q);
            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "Ok");
        }
        finally
        {
			lst_produtos.IsRefreshing = false;
		}
    }

    private async void lst_produtos_Refreshing(object sender, EventArgs e)
    {
        try
        {
            lst_produtos.IsRefreshing = true;
            lista.Clear();
            List<Produto> tmp = await App.Db.GetAll();
            tmp.ForEach(i => lista.Add(i));
            txt_search.Text = "";
        }
        catch (Exception ex)
        {
			await DisplayAlertAsync("Erro", ex.Message, "Ok");
		}
        finally
        {
			lst_produtos.IsRefreshing = false;
		}
    }

    private async void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto? p = e.SelectedItem as Produto;
            await Navigation.PushAsync(new Views.CadastroProduto
            {
                BindingContext = p
            });
        }
        catch (Exception ex)
        {
			await DisplayAlertAsync("Erro", ex.Message, "Ok");
		}
        finally
        {
        }
    }

    private async void MenuItem_Clicked_Remover(object sender, EventArgs e)
    {
        try
        {
            MenuItem? selecionado = sender as MenuItem;
            Produto? p = selecionado?.BindingContext as Produto;

            lst_produtos.IsRefreshing = true;

            bool confirmacao = await DisplayAlertAsync(
                "Tem certeza?",
                $"Deseja excluir o item: {p.Descricao}?",
                "Sim", "Cancelar");

            if (confirmacao)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {
			await DisplayAlertAsync("Erro", ex.Message, "Ok");
		}
        finally
        {
			lst_produtos.IsRefreshing = true;
		}
    }
}