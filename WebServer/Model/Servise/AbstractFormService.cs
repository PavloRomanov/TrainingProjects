using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace Model.Servise
{
    public abstract class AbstractFormService : SQLService<Form>
    {
        public AbstractFormService(string tableName)
            :base("Forms")
        {
        }

       
    }
}
