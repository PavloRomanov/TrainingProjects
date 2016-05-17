using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebShop.Model.Entities
{
    [Table("Categories")]
    public class Category : VersionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required, MaxLength(40)]
        public string CategoryName { get; set; }
    }
}
