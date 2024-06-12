using Ct.common.Entities;
using Ct.Dal.Data;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.ClassDal
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddUser(Users users)
        {
            dbContext.UsersTable.Add(users);
            dbContext.SaveChanges();
        }
        public void DeleteUserById(int id)
        {
            var user = dbContext.UsersTable.Find(id);
            if (user != null)
            {
                dbContext.UsersTable.Remove(user);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUsers(Users user, int id)
        {
            var users = dbContext.UsersTable.Find(id);
            if (users != null) { 
                 users.Username = user.Username;
                users.Password = user.Password;
                dbContext.SaveChanges();
            }
        }
        public void PasswordChange(Users user, int id)
        {
            var users = dbContext.UsersTable.Find(id);
            if (users != null)
            {
                users.Password = user.Password;
                dbContext.SaveChanges();
        }   }

        public List<Users> GetAllUsers()
        {
            return dbContext.UsersTable.ToList();
        }
    }

}
