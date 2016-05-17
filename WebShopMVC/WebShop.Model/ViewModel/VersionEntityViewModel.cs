using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.ViewModel
{
    public abstract class VersionEntityViewModel
    {
        public DateTime RowVersion { get; set; }
    }
}
