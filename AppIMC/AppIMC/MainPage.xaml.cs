namespace AppIMC
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {   //Método para calcular o IMC quando clicar no botão

            double altura_imc = Convert.ToDouble(altura.Text);
            double peso_imc = Convert.ToDouble(peso.Text);
            string resposta = "";
            double imc = (peso_imc / (altura_imc * altura_imc));
            decimal imcDecimal = Convert.ToDecimal(imc);

            if (imc < 18.5)
            {
                resposta = $"Classificação Magreza - IMC: {imcDecimal}";
            } 
            else if (imc > 18.5 && imc <= 24.9)
            {
                resposta = $"Classificação Normal - IMC: {imcDecimal}";
            } 
            else if (imc >= 25 && imc < 29.9)
            {
                resposta = $"Classificação Sobrepeso - IMC: {imcDecimal}";
            }
            else if (imc >= 30 && imc < 34.9)
            {
                resposta = $"Classificação Obesidade Grau I - IMC: {imcDecimal}";
            }
            else if (imc >= 35 && imc < 39.9)
            {
                resposta = $"Classificação Obesidade Grau II - IMC: {imcDecimal}";
            }
            else if (imc >= 40)
            {
                resposta = $"Classificação Obesidade Grau III - IMC: {imcDecimal}";
            }

            await DisplayAlertAsync("Resposta", resposta, "OK");
        }
    }
}
