using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.Entities
{
public class Image : Base
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Required, MaxLength(30)]

    public string FileName { get; set; }

    public bool MainPicture { get; set; }

    public byte[] Picture { get; set; }

    public string ImageMineType { get; set; }
}
}
