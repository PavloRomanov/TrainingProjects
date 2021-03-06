﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Model.Entities
{
    [Table("Users")]
    public abstract class User : VersionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(10), MinLength(3)]
        public string Login { get; set; }

        [MaxLength(10), MinLength(3)]
        public string Password { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }        
    }
}
