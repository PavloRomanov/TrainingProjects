using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace Model.Servise
{
    public abstract class AbstractManagerService : IService<Manager>
    {
        public void Add(Manager model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, Manager> GetAll()
        {
            throw new NotImplementedException();
        }

        public Manager GetElement(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Update(Manager model)
        {
            throw new NotImplementedException();
        }
    }
}
