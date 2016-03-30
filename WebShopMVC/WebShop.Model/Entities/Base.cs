﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Model.Entities
{
    public class Base
    {
        public Base()
        {
            this.RowVersion = new DateTime();
        }

        [ConcurrencyCheck]
        [Required]
        [Column(TypeName="DateTime2")]
        public DateTime RowVersion { get; set; }
    }
}
