using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Data.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsApp.Core.Data.SqlServer.Repository
{
    public class RepositorySqlServer<T> : IRepositorySqlServer<T> where T : class
    {
        protected readonly NewsAppDbContext _context;
        public RepositorySqlServer(NewsAppDbContext context)
        {
            _context = context;
        }
        protected void Save() => _context.SaveChanges();

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        //public IEnumerable<T> Find(Func<T, bool> predicate)
        //{
        //    return _context.Set<T>().Where(predicate);
        //}

        //public int Count(Func<T, bool> predicate)
        //{
        //    return _context.Set<T>().Where(predicate).Count();
        //}
    }
}
