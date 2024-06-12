using Ct.common.Entities;
using Ct.common.Models;
using Ct.Dal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.InterfacesDal
{
    public interface ILoginRepository
    {
        Users GetUser(string username);
        
    }
}
