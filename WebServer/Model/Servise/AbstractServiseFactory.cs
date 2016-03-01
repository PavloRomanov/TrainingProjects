using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;
using Model.Servise;

namespace Model.Servise
{
    public abstract class AbstractServiseFactory<T> where T : ModelBase
    {
        public abstract IServise<T> CreateServise();
    }
}
