using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Model.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Display(Name = "Name of Category")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string CategoryName { get; set; }
    }
}
