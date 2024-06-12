using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.common.Models
{
    public class ClothModel
    {
        public string? Cloth_name { get; set; }

       public int Cloth_price { get; set; }

        public int Category_id { get; set; }

        public int Brand_id { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTime { get; set; } = System.DateTime.Now;
    }
}
