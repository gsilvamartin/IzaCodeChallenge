using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzaCodeChallenge.Model.Database
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
    }
}

