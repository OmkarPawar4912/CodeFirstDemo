using DemoRepoPattern.Data;
using DemoRepoPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoRepoPattern.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationBDContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(ApplicationBDContext bdContext)
        {
            _context = bdContext;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public int SaveChanges()
        {
            var result = _context.SaveChanges();
            return result;
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
