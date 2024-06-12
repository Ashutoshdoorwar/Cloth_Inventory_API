using Ct.common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.InterfacesBal
{
    public interface IUserService
    {
        public void AddUser(UsersModel model);

        public void DeleteUserById(int id);

        public void UpdateUsers(UsersModel model,int id);

        public List<UsersModel> GetAllUsers();
    }
}
