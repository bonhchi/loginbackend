using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ShopDbContext _shopDbContext;

        public Repository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public void Delete(Guid id)
        {
            _shopDbContext.Remove(_shopDbContext.Find(typeof(T), id));
            _shopDbContext.SaveChanges();
        }

        public T Find(Guid id)
        {
            return (T)_shopDbContext.Find(typeof(T), id);
        }

        public IEnumerable<T> GetAll()
        {
            return _shopDbContext.Set<T>().ToList();
        }

        public T Insert(T entity)
        {
            _shopDbContext.Add(entity);
            _shopDbContext.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _shopDbContext.Entry(entity).State = EntityState.Modified;
            _shopDbContext.SaveChanges();
        }

        public T Detail(Guid id)
        {
            return _shopDbContext.Set<T>().FirstOrDefault(p => p.Id == id);
        }
    }
}
