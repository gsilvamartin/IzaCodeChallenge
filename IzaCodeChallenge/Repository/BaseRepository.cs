using System;
using IzaCodeChallenge.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IzaCodeChallenge.Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext!.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public int Insert(T obj)
        {
            _dbSet.Add(obj);

            return Save();
        }

        public void Update(T obj)
        {
            _dbSet.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;

            Save();
        }

        public void Delete(int id)
        {
            T existing = _dbSet.Find(id)!;
            _dbSet.Remove(existing);

            Save();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

