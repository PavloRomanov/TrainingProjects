using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace Model.Servise
{
    public abstract class AbstractFormService : IService<Form>
    {
        public void Add(Form model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Guid, Form> GetAll()
        {
            throw new NotImplementedException();
        }

        public Form GetElement(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Update(Form model)
        {
            throw new NotImplementedException();
        }
    }
}
