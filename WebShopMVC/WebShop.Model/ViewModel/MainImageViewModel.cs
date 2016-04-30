using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebShop.Model.ViewModel
{
    public class MainImageViewModel
    {
        public int ImageId { get; set; }

        public int ProductId { get; set; }

        public bool MainPicture { get; set; }

        [Required(ErrorMessage = "please enter name file")]
        [StringLength(30, MinimumLength = 2)]
        public string FileName { get; set; }

        public HttpPostedFileBase Image { get; set; }

        
        
        
    }
}
