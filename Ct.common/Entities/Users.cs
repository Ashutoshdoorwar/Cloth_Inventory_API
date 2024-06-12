using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.common.Entities
{
    public class Users
    {
        [Key]
        public int Users_id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
