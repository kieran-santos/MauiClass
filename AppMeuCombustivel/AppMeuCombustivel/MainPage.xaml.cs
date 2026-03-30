namespace AppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {   //Método que define o que a interface deve fazer
            //É possível identificar qual botão disparou o evento, pois vários podem chamar o mesmo evento (definido pelo object sender)

            double preco_gasolina = Convert.ToDouble(gasolina.Text);
            double preco_etanol = Convert.ToDouble(etanol.Text);
            string msg = "";

            if(preco_etanol > (preco_gasolina * 0.7))
            {
                msg = "Compensa a gasolina";
            } else
            {
                msg = "Compensa o etanol";
            }
            await DisplayAlertAsync("Resultado:", msg, "OK");
        }
    }
}
