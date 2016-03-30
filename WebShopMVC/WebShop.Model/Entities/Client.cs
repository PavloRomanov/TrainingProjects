using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Model.Entities
{

    public class Client : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Required, MaxLength(20)]        
        public string FirstName { get; set; }

        [Required, MaxLength(20)]       
        public string LastName { get; set; }

        [MaxLength(16)]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(10), MinLength(3)]
        public string Login { get; set; }
        
        [MaxLength(10), MinLength(3)]
        public string Password { get; set; }
    }
}
