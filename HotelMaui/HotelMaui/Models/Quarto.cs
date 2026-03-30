namespace HotelMaui.Models
{
    public class Quarto
    {
        public string Descricao { get; set; } = String.Empty;
        public double ValorDiariaAdulto { get; set; }
        public double ValorDiariaCrianca { get; set; }

        public string NomeComPreco
        {
            get
            {
                return $"{Descricao} Adultos: {ValorDiariaAdulto:C}";
                //:C vai formatar para ficar como moeda (currency)
            }
        }
    }
}
