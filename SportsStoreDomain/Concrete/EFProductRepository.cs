using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreDomain.Abstract;
using SportsStoreDomain.Entities;

namespace SportsStoreDomain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDBContext _context = new EFDBContext();

        public IEnumerable<Product> Products
        {
            get { return _context.Products; }
        }
    }
}
