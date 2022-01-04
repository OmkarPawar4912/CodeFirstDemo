using System;
using System.Collections.Generic;

namespace DemoRepoPattern.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        int SaveChanges();
    }
}
