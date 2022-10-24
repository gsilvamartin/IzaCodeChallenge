using System;
using IzaCodeChallenge.Model.Database;

namespace IzaCodeChallenge.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        int Save();
    }
}

