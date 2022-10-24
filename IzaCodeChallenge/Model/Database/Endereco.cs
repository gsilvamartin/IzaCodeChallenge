using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzaCodeChallenge.Model.Database
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
    }
}

