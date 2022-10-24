using System;
using IzaCodeChallenge.Model.Database;
using IzaCodeChallenge.Repository.Interfaces;
using IzaCodeChallenge.Service.Interfaces;

namespace IzaCodeChallenge.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IBaseRepository<Produto> _produtoRepository;

        public ProdutoService(IBaseRepository<Produto> produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public void DeleteProduto(int id)
        {
            _produtoRepository.Delete(id);
        }

        public Produto GetProduto(int id)
        {
            return _produtoRepository.GetById(id);
        }

        public IEnumerable<Produto> GetProdutosByClienteId(int id)
        {
            return _produtoRepository.Get().Where(x => x.IdCliente == id);
        }

        public IEnumerable<Produto> GetProdutos()
        {
            return _produtoRepository.Get();
        }

        public int InsertProduto(Produto produto)
        {
            return _produtoRepository.Insert(produto);
        }

        public void UpdateProduto(Produto produto)
        {
            _produtoRepository.Update(produto);
        }
    }
}

