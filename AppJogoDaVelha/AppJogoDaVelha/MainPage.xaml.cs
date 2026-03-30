using System.Diagnostics;

namespace AppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        //Classe da MainPage - tudo isso é acessado na MainPage
        //Partial é pra extender partes de ContentPage e não ela inteira - se não me obriga a usar tudo
        string vez = "X";

        //Aqui criamos a variável matriz onde vamos guardar os valores X ou O de cada botão
        string[,] matriz = new string[3, 3];

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button clicado = (Button)sender; //Para reconhecer qual botão você clicou
            clicado.Text = vez;   //O botão clicado vai mostrar esse valor


            vez = (vez == "X") ? "O" : "X"; //Vez começa como X, se vez for X ele troca para O, se for O ele troca para X

            ////Para salvar o valor X ou O pegamos os valores de coluna e linha para colocar na matriz
            int coluna1 = Grid.GetColumn(clicado);
            int linha1 = Grid.GetRow(clicado);  

            ////Colocando o valor na matriz
            matriz[linha1, coluna1] = vez;

            Verificar_Vencedor();

            //PERCORRENDO BOTÕES - TIAGO
            //Criando um loop de matriz do jogo da velha para saber a posição de cada X e O
            //Esse loop será utilizado para ver quem ganhou no final

            /*foreach (var x in jogo.Children)   //A propriedade Children pega todos os filhos do elemento
            {                                   //Os filhos da grid são label e button
                if(x is Button btn)            //Pra pegar só os button
                {
                    int coluna = Grid.GetColumn(btn);   //Pega o valor de Grid.Column do botão
                    int linha = Grid.GetRow(btn);   //Pega o valor de Grid.Row do botão

                    Debug.WriteLine(btn.Text);   //É o console.log - pra ver no debug
                    Debug.WriteLine(coluna);
                    Debug.WriteLine(linha);
                }
            }*/

            //Se retornar true ele mostra quem venceu
            if (Verificar_Vencedor())
            {
                await DisplayAlertAsync("Parabéns", $"O jogador {((vez == "X") ? "O" : "X")} venceu!", "OK");
            }
        }

        public bool Verificar_Vencedor()
        {
            //Verificando se alguém ganhou
            for (int i = 0; i < 3; i++)
            {
                //Verificando linhas
                if (matriz[i, 0] != null && matriz[i, 0] == matriz[i, 1] && matriz[i, 1] == matriz[i, 2]) return true;
                //Verificando colunas
                if (matriz[0, i] != null && matriz[0, i] == matriz[1, i] && matriz[1, i] == matriz[2, i]) return true;
            }

            if (matriz[0, 0] != null && matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2]) return true;
            if (matriz[0, 2] != null && matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0]) return true;

            return false;
        }
    }
}
