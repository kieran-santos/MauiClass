using System;
using System.Collections.Generic;
using System.Text;

namespace HotelMaui.Models
{
    public class Hospedagem
    {
        Quarto quarto_selecionado = new();

        public Quarto QuartoSelecionado
        {   get => quarto_selecionado;
          
            set
            {
                if(value == null)
                    throw new Exception("Selecione um quarto");

                quarto_selecionado = value;
            }
        }   
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn {  get; set; }
        public DateTime DataCheckOut { get; set; }
        public int Estadia 
        {
            get
            {
                return DataCheckOut.Subtract(DataCheckIn).Days; //Days é a função do tipo de objeto DateTime
                //return (DataCheckOut - DataCheckIn).Days
            }

            //get => (DataCheckOut - DataCheckIn).Days
            //Usar apenas quando cabe em uma única linha

        } //Não deve ter set pois Estadia será calculada sozinha
        public double ValorTotal //Vai calcular o valor da hospedagem
        {
            get
            {
                //Pegamos o valor da diaria por pessoa
                double valor_adulto = QntAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_crianca = QntCriancas * QuartoSelecionado.ValorDiariaCrianca;

                //Multiplicamos pelos dias que vão ficar no hotel
                double valor_total = (valor_adulto + valor_crianca) * Estadia;

                return valor_total;
            }
        }

    }
}
