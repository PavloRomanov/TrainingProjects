using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Model.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Логин")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 3)]
        public string Password { get; set; }
    }
}
