namespace MauiApp_MinhasCompras.Views;

public partial class ListaProdutos : ContentPage
{
	public ListaProdutos()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = new List<Models.Produto>()
        {
            new Models.Produto() {Id=1, Descricao="Maçã", Preco=10.95, Quantidade=2.40},
            new Models.Produto() {Id=2, Descricao="Maracujá", Preco=7.95, Quantidade=1.23},
            new Models.Produto() {Id=3, Descricao="Alface", Preco=8.99, Quantidade=1},
            new Models.Produto() {Id=4, Descricao="Banana Nanica", Preco=8.70, Quantidade=2.10},
            new Models.Produto() {Id=5, Descricao="Tomate", Preco=6.95, Quantidade=3.21}
        };

    }

    private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
    {

    }

    private void ToolbarItem_Clicked_Adicionar(object sender, EventArgs e)
    {

    }

    private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void lst_produtos_Refreshing(object sender, EventArgs e)
    {

    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void MenuItem_Clicked_Remover(object sender, EventArgs e)
    {

    }
}