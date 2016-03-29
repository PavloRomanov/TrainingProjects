using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Model.ViewModel
{
    public class SubcategoryViewModel
    {
        public int SubcategoryId { get; set; }

        public int CategoryId { get; set; }


        [Display(Name = "Name of SubCategory")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string SubcategoryName { get; set; }


        public string CategoryName { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
