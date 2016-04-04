using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.ViewModel
{
    public class CompositeCategoryViewModel : CategoryViewModel
    {
        public IEnumerable<SubcategoryViewModel> Subcategories { get; set; }        
    }
}
