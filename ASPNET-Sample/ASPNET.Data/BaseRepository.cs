using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPNET.Data.Interfaces;
using System.Data.Objects;
using System.Linq.Expressions;



namespace ASPNET.Data
{
   
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private IRepositoryContext _repositoryContext;

        private IObjectSet<T> _objectSet;

        public BaseRepository() : this(new Repositorycontext()) { }

        public BaseRepository(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext = repositoryContext ?? new Repositorycontext();
            _objectSet = _repositoryContext.GetObjectSet<T>();
        }

        public IRepositoryContext RepositoryContext
        {
            get
            {
                return this._repositoryContext;
            }
        }

        public IObjectSet<T> ObjectSet
        {
            get
            {
                return _objectSet;
            }
        }

        public void Add(T entity)
        {
            this.ObjectSet.AddObject(entity);
            this.RepositoryContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.ObjectSet.DeleteObject(entity);
            this.RepositoryContext.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return this.ObjectSet.ToList<T>();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).ToList<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).FirstOrDefault<T>();
        }

        public void Attach(T entity)
        {
            this.ObjectSet.Attach(entity);
        }


        public void SaveChanges()
        {
            this.RepositoryContext.SaveChanges();
        }

        public IQueryable<T> GetQueryable()
        {
            return this.ObjectSet.AsQueryable<T>();
        }

        public long Count()
        {
            return this.ObjectSet.LongCount<T>();
        }

        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            return this.ObjectSet.Where(whereCondition).LongCount<T>();
        }
    }
}





