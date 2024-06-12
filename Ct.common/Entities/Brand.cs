using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.common.Entities
{
    public class Brand
    {
        [Key]
     
        public int Brand_id { get; set; }

        public string? Brand_name { get; set; }

    }
}
