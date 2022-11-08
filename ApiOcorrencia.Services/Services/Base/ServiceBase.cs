using ApiOcorrencia.Infra.Repository.Interfaces.Base;
using ApiOcorrencia.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiOcorrencia.Services.Services.Base
{
    public class ServiceBase<T>: IServiceBase<T>, IDisposable where T:class
    {
        private readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> Repository)
        {
            _repository = Repository;
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
