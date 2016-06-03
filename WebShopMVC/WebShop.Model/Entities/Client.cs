using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Model.Entities
{
    [Table("Clients")]
    public class Client : User
    {
        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(16)]
        public string Phone { get; set; }

        public DateTime Birthday { get; set; }
    }
}