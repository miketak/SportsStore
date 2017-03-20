﻿using System.Collections.Generic;
using SportsStoreDomain.Abstract;
using SportsStoreDomain.Entities;

namespace SportsStoreDomain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDBContext _context = new EFDBContext();

        public IEnumerable<Product> Products
        {
            get { return _context.Products; }
        }


        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var dbEntry = _context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }


        public Product DeleteProduct(int productID)
        {
            Product dbEntry = _context.Products.Find(productID);
            if (dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}