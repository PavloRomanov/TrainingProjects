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
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int SubcategoryId { get; set; }

        [Display(Name = "Name of SubCategory")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string SubcategoryName { get; set; }
    }
}
