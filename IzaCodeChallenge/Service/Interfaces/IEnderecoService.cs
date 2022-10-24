using System;
using IzaCodeChallenge.Model.Database;

namespace IzaCodeChallenge.Service.Interfaces
{
    public interface IEnderecoService
    {
        public int InsertEndereco(Endereco endereco);
        public void UpdateEndereco(Endereco endereco);
        public void DeleteEndereco(int id);
        public Endereco GetEndereco(int id);
        public Endereco GetEnderecoByClienteId(int id);
        public IEnumerable<Endereco> GetEnderecos();
    }
}

