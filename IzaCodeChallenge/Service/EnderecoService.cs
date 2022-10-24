using System;
using IzaCodeChallenge.Model.Database;
using IzaCodeChallenge.Repository.Interfaces;
using IzaCodeChallenge.Service.Interfaces;

namespace IzaCodeChallenge.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IBaseRepository<Endereco> _enderecoRepository;

        public EnderecoService(IBaseRepository<Endereco> enderecoRepository)
        {
            this._enderecoRepository = enderecoRepository;
        }

        public void DeleteEndereco(int id)
        {
            _enderecoRepository.Delete(id);
        }

        public Endereco GetEndereco(int id)
        {
            return _enderecoRepository.GetById(id);
        }

        public Endereco GetEnderecoByClienteId(int id)
        {
            return _enderecoRepository.Get().Where(x => x.IdCliente == id).First();
        }

        public IEnumerable<Endereco> GetEnderecos()
        {
            return _enderecoRepository.Get();
        }

        public int InsertEndereco(Endereco endereco)
        {
            var existeEndereco = _enderecoRepository.Get().Where(x => x.IdCliente == endereco.IdCliente).Any();

            if (!existeEndereco)
                return _enderecoRepository.Insert(endereco);
            else
                throw new Exception("Cliente já tem endereço cadastrado");
        }

        public void UpdateEndereco(Endereco endereco)
        {
            _enderecoRepository.Update(endereco);
        }
    }
}

