using Ct.common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Dal.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {



        }
        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<Brand> BrandTable { get; set; }
        public DbSet<Cloth> ClothTable { get; set; }
        public DbSet<Stock> StockTable { get; set; }
        public DbSet<Users> UsersTable { get; set; }

    }
}
