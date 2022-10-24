using System;
using System.ComponentModel.DataAnnotations;

namespace IzaCodeChallenge.Model.Database
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

