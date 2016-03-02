using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace Model.Servise
{
    public abstract class AbstractAppealService : SQLService<Appeal>
    {
        public AbstractAppealService(string tableName)
            :base("Appeals")
        {
        }
       
    }
}
