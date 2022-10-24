using System;
using IzaCodeChallenge.Model.Database;

namespace IzaCodeChallenge.Service.Interfaces
{
    public interface IProdutoService
    {
        public int InsertProduto(Produto produto);
        public void UpdateProduto(Produto produto);
        public void DeleteProduto(int id);
        public Produto GetProduto(int id);
        public IEnumerable<Produto> GetProdutosByClienteId(int id);
        public IEnumerable<Produto> GetProdutos();
    }
}

