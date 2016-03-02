using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace Model.Servise
{
    public abstract class AbstractAppealService : IService<Appeal>
    {
        public void Add(Appeal model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, Appeal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appeal GetElement(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Update(Appeal model)
        {
            throw new NotImplementedException();
        }
    }
}
