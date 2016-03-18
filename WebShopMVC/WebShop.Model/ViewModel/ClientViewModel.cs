using System;
using System.ComponentModel.DataAnnotations;


namespace WebShop.Model.ViewModel
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Контактный телефон:")]
        [StringLength(13)]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\d{3}-\d{3}-\d{2}-\d{2}")]
        public string Phone { get; set; }
        
        [Display(Name = "Электронная почта")]
        [StringLength(30)]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

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
