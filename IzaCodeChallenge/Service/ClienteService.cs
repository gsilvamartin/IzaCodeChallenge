using System;
using IzaCodeChallenge.Model.Database;
using IzaCodeChallenge.Repository.Interfaces;
using IzaCodeChallenge.Service.Interfaces;

namespace IzaCodeChallenge.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IBaseRepository<Cliente> _clienteRepository;

        public ClienteService(IBaseRepository<Cliente> clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public bool IsUserValid(string username, string password, out string Id)
        {
            var user = _clienteRepository.Get().Where(x => x.Email == username && x.Senha == password).FirstOrDefault();

            if (user is not null)
            {
                Id = user.IdCliente.ToString();
                return true;
            }
            else
            {
                Id = string.Empty;
                return false;
            }
        }

        public void DeleteCliente(int id)
        {
            _clienteRepository.Delete(id);
        }

        public Cliente GetCliente(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _clienteRepository.Get();
        }

        public int InsertCliente(Cliente cliente)
        {
            return _clienteRepository.Insert(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clienteRepository.Update(cliente);
        }
    }
}

