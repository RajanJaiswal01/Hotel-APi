﻿using System.Linq.Expressions;

namespace TestHotel.Common
{
  
        public interface IRepository<T> where T : class
        {
            IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
            IQueryable<T> All { get; }
            IQueryable<T> GetMany();
            IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
            T GetById(int id);
            T GetById(Int64 id);
            T GetById(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
            Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
            Task<T> GetSingle(int id);
            Task<T> GetSingle(Int64 id);
            IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
            Task Add(T entity);
            void Delete(T entity);

        }
    
}
