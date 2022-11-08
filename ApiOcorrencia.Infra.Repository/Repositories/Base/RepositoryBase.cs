using ApiOcorrencia.Infra.Context;
using ApiOcorrencia.Infra.Repository.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiOcorrencia.Infra.Repository.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        public RepositoryBase()
        {

        }

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
