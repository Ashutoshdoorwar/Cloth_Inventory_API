using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.common.Entities
{
    public class Stock
    {
        [Key]
        public int Stock_id { get; set; }
        public int Cloth_id { get; set; }
        public int Quantity { get; set; }
        public string? Cloth_name { get; set; }

        public int Cloth_price { get; set; }
        public DateTime Date { get; set; }
    }
}
