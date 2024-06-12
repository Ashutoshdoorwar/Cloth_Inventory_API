using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.common.Entities
{
    public class Category
    {
        [Key]
        public int Category_id { get; set; }
        public string? Category_name { get; set; }
    }
}
