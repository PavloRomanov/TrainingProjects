using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.ViewModel
{
    public class ProductViewModelWithImage:ProductViewModel
    {
        public byte[] Picture { get; set; }
        public string ImageMineType { get; set; }

        public bool MainPicture { get; set; }

    }
}
