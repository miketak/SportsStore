using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreDomain.Entities;
using System.Data.Entity;

namespace SportsStoreDomain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
