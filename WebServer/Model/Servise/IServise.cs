using System;
using System.Collections.Generic;
using Model.Entity;

namespace Model.Servise
{
    public interface IServise<T> where T : ModelBase
    {
        T GetElement(Guid key);
        Dictionary<Guid, T> GetAll();
        void Add(T model);
        void Delete(Guid id);
        void Update(T model);
    }
}
