using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        [Display(Name = "Name of product")]
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string ProductName { get; set; }

        [Display(Name = "Discription of product")]
        [StringLength(200)]
        public string Description { get; set; }

        [Display(Name = "Price of product")]
        [Required]
        [RegularExpression(@"\d{1,7}\.\d{2}|\d{3}")]
        [StringLength(10, MinimumLength = 2)]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        [StringLength(2, MinimumLength = 1)]
        [RegularExpression(@"\d{2}|\d")]
        public ushort Discount { get; set; }
    }
}
