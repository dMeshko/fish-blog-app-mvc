using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace blog_app_mvc.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly UnitOfWork _unitOfWork;

        protected ISession Session => _unitOfWork.Session;

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public virtual void Add(T entity)
        {
            _unitOfWork.BeginTransaction();
            Session.Save(entity);
            _unitOfWork.Commit();
        }

        public virtual void Update(T entity)
        {
            _unitOfWork.BeginTransaction();
            Session.Update(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            _unitOfWork.BeginTransaction();
            Session.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = Session.Query<T>().Where(where);

            foreach (T obj in objects)
                Session.Delete(obj);
        }

        public virtual T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return Session.Query<T>().Where(where).FirstOrDefault();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return Session.Query<T>().Where(where);
        }

        public virtual bool IsUnique(T entity) => !Session.Query<T>().Any();
    }
}