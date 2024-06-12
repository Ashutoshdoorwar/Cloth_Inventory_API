using Ct.common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.InterfacesDal
{
    public interface IUserRepository
    {
        public void AddUser(Users users);

        public void DeleteUserById(int id);

        public void UpdateUsers(Users user, int id);

        public List<Users> GetAllUsers();
    }
}
