using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.Entities;

namespace WebShop.Model.ViewModel
{
   public class CartViewModel
    {       
        public int CartId;

        [Display(Name = "Clients")]
        public int ClientId { get; set; }

        public Product Product { get; set; }


        [Display(Name = "Quantity units sold")]
        [Required(ErrorMessage = "please enter quantity of product")]
        [Range(0, 1000)]
        [RegularExpression(@"\d{3}\d{2}|\d")]
        public int Quantity { get; set; }
    }
}
