using System;
using IzaCodeChallenge.Model.Database;

namespace IzaCodeChallenge.Service.Interfaces
{
    public interface IClienteService
    {
        public bool IsUserValid(string username, string password, out string id);
        public int InsertCliente(Cliente cliente);
        public void UpdateCliente(Cliente cliente);
        public void DeleteCliente(int id);
        public Cliente GetCliente(int id);
        public IEnumerable<Cliente> GetClientes();
    }
}

