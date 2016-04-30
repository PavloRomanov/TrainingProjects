using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Model.ViewModel
{
   public class PartImageViewModel
    {
        public bool MainPicture { get; set; }

        public string FileName { get; set; }

        public int ImageId { get; set; }

        public int ProductId { get; set; }

    }
}
