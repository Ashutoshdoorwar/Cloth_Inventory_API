using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.common.Entities
{
    public class Cloth
    {
        [Key]
        public int Cloth_id { get; set; }
        public string? Cloth_name { get; set; }
        public int Category_id { get; set; }
        public string? Category_name { get; set; }
        public int Brand_id { get; set; }
        public string? Brand_name { get; set; }
        public int Quantity { get; set; }
        
       

    }
}
