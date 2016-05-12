using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Model.Entities
{
    [Table("Employees")]
    public class Employee : User
    {
        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(256)]
        public string Address { get; set; }

        [MaxLength(16)]
        public string Phone { get; set; }

        public Role Role { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsDelete { get; set; }
    }
}