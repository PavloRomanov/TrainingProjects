using System;
using System.ComponentModel.DataAnnotations;


namespace WebShop.Model.ViewModel
{
    public class ClientViewModel : UserViewModel
    {
        [Display(Name = "Имя")]        
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]        
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Контактный телефон:")]
        [StringLength(13)]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\d{3}-\d{3}-\d{2}-\d{2}")]
        public string Phone { get; set; }

        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
