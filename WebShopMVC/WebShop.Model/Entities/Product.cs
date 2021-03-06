﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Model.Entities
{
    [Table("Products")]
    public class Product : VersionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public int SubcategoryId { get; set; }

        [ForeignKey("SubcategoryId")]
        public Subcategory Subcategory { get; set; }

        [Required, MaxLength(30)]
        public string ProductName { get; set; }
              
        [Required]
        public decimal Price { get; set; }

        public int Discount { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

 
    }
}
