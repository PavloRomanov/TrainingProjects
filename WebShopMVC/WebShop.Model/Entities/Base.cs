using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Model.Entities
{
    public abstract class Base
    {
        [ConcurrencyCheck]
        [Required]
        [Column(TypeName="DateTime2")]
        public DateTime RowVersion { get; set; }
    }
}
