using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.ViewModel
{
   public class ImageViewModel
    {
        public int ImageId { get; set; }

        public int ProductId { get; set; }

       // [Required]
       // [StringLength(30, MinimumLength = 2)]
       // public string FileName { get; set; }

        [Required]
        public bool MainPicture { get; set; }
        public string ImageMineType { get; set; }

        [Required]
        public byte[] Picture { get; set; }

    }
}
