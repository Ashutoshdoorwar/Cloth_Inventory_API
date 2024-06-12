using Ct.common.Entities;
using Ct.common.Models;
using Ct.Dal.Data;
using Ct.Dal.InterfacesDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.ClassDal
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext dbContext;
        public LoginRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Users GetUser(string username)
        {
         //here it return entity model convert into model in bussiness layerr...
            var user = dbContext.UsersTable.FirstOrDefault(c => c.Username == username);

            return user;
        }
    }
}
