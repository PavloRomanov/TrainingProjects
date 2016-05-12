using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebShop.Model.Entities;

namespace WebShop.Model.ViewModel
{
    public class UserViewModel : BaseVievModel
    {
        public int UserId { get; set; }
                
        [Display(Name = "Login : ")]
        [Required(ErrorMessage = "Please, enter login!")]
        [StringLength(10, MinimumLength = 3)]
        public string Login { get; set; }

        [Display(Name = "Password : ")]
        [Required(ErrorMessage = "Please, enter password!")]
        [StringLength(10, MinimumLength = 3)]
        public string Password { get; set; }        

        [Display(Name = "Email : ")]
        [Required(ErrorMessage = "Please, enter email!")]
        [MaxLength(30)]
        public string Email { get; set; }
       
    }
}
