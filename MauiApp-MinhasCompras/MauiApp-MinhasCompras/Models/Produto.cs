using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp_MinhasCompras.Models
{
    public class Produto
    {
        //Usando SQLite para modelar o banco
        string _descricao = "";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                    throw new Exception("Informe o nome do produto.");
                _descricao = value;
            }
        }
        public double Quantidade { get; set; }
        public double Preco {  get; set; }
        public double Total { get => Quantidade * Preco; }
    }
}
