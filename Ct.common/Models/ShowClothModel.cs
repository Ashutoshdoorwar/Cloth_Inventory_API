using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Common.Models
{
    public class ShowClothModel
    {
        public int Cloth_id { get; set; }

        public string? Cloth_name { get; set; }

        //public int Cloth_price { get; set; }

        public int Category_id { get; set; }

        public string? Category_name { get; set; }

        public int Brand_id { get; set; }

        public string? Brand_name { get; set; }

        public int Quantity { get; set; }
    }
}
