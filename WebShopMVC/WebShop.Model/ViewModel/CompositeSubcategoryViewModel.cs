using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.ViewModel
{
    public class CompositeSubcategoryViewModel : SubcategoryViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
