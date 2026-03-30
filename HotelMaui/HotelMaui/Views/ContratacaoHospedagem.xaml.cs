using HotelMaui.Models;

namespace HotelMaui.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    List<Quarto> lista_quartos = new()
    {
        new Quarto
        {
            Descricao = "Suíte Super Luxo",
            ValorDiariaAdulto = 110.0,
            ValorDiariaCrianca = 55
        },

        new Quarto
        {
            Descricao = "Suíte Luxo",
            ValorDiariaAdulto = 80.0,
            ValorDiariaCrianca = 40
        },

        new Quarto
        {
            Descricao = "Suíte Single",
            ValorDiariaAdulto = 50.0,
            ValorDiariaCrianca = 25
        },

        new Quarto
        {
            Descricao = "Suíte Crise",
            ValorDiariaAdulto = 25,
            ValorDiariaCrianca = 12.5
        }
    };


	public ContratacaoHospedagem()
	{
		InitializeComponent();
        //Abastecendo o picker com a lista de quartos
        pck_quarto.ItemsSource = lista_quartos;

        //Validando a data mínima do checkin
        dtpck_checkin.MinimumDate = DateTime.Now;
        //Validando a data máxima do checkin
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

        //Validando a data mínima do checkout - tem que ser maior que o checkin
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        //Validando a data máxima do checkout - máximo de dias que a pessoa pode ficar no hotel
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);
	}

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        //Para mudar a data do checkout quando eu selecionar a data do checkin
        DatePicker elemento = (DatePicker)sender;

        DateTime data_selecionada = elemento.Date.Value;

        dtpck_checkout.MinimumDate = data_selecionada.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada.AddMonths(2);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //Vamos coletar os dados inputados pelo usuário
        try
        {
            //Criando um objeto Hospedagem
            Hospedagem h = new()
            {
                QuartoSelecionado = (Quarto) pck_quarto.SelectedItem, //(Quarto) é um typecast pra avisar que o objeto do picker é um Quarto
                DataCheckIn = (DateTime) dtpck_checkin.Date,
                DataCheckOut = (DateTime) dtpck_checkout.Date,
                QntAdultos = Convert.ToInt32(stp_adultos.Value), //O Convert trata erros
                QntCriancas = (int) stp_criancas.Value,
            };

            //Criação da nova tela, onde serão mostrados os dados da hospedagem
            HospedagemContratada hc = new();

            //Juntando o esqueleto da tela com os dados da hospedagem
            hc.BindingContext = h;

            //Navegando de tela, indo para a tela criada anteriormente (linha 82)
            await Navigation.PushAsync(hc);


            //Forma mais compacta
            /*await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h,
                //Estamos amarrando a nova tela (HospedagemContratada) com o objeto h que instanciamos
            });*/


            //Ainda mais compacto
            /*
             await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = new Hospedagem()
                {
                    QuartoSelecionado = (Quarto) pck_quarto.SelectedItem, //(Quarto) é um typecast pra avisar que o objeto do picker é um Quarto
                    DataCheckIn = (DateTime) dtpck_checkin.Date,
                    DataCheckOut = (DateTime) dtpck_checkout.Date,
                    QntAdultos = Convert.ToInt32(stp_adultos.Value), //O Convert trata erros
                    QntCriancas = (int) stp_criancas.Value,
                }
            });
             */

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }

    }

    private void dtpck_checkout_DateSelected(object sender, DateChangedEventArgs e)
    {

    }
}