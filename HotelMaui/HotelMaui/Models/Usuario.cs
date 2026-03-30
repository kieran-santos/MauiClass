using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HotelMaui.Models
{
    //Trocar o internal por public
    public class Usuario
    {
        string _nome = "";
        public string Nome
        {
            get => _nome;

            set
            {
                if (value == null)
                    throw new Exception("Informe seu nome");
            }
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
