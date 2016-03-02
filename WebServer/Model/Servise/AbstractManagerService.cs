using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace Model.Servise
{
    public abstract class AbstractManagerService : SQLService<Manager>
    {
        public AbstractManagerService(string tableName)
            :base("Managers")
        {
        }
        
    }
}
