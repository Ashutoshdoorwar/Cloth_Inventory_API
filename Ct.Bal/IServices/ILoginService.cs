using Ct.common.Entities;
using Ct.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.InterfacesBal
{
    public interface ILoginService
    {
         public UsersModel AuthenticationUser(UsersModel user);
         public string GenerateToken(UsersModel user);

    }
}
