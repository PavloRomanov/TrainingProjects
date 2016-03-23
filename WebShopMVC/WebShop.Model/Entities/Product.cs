using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Model.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required, MaxLength(30)]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Discount { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

    }
}
