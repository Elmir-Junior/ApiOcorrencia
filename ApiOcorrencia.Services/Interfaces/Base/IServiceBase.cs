using System;
using System.Collections.Generic;
using System.Text;

namespace ApiOcorrencia.Services.Interfaces.Base
{
    public interface IServiceBase<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
