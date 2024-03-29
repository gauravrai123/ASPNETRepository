﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ASPNET.Data.Interfaces
{
   public  interface IRepository<T>
    {
        T GetSingle(Expression<Func<T, bool>> whereCondition);
        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        IList<T> GetAll(Expression<Func<T, bool>> whereCondition);
        IList<T> GetAll();
        IQueryable<T> GetQueryable();
        long Count(Expression<Func<T, bool>> whereCondition);
        long Count();

    }
}
