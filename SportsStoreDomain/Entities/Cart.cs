﻿using System.Collections.Generic;
using System.Linq;

namespace SportsStoreDomain.Entities
{
    public class Cart
    {
        private readonly List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void AddItem(Product product, int quantity)
        {
            var line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (line == null)
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            else line.Quantity += quantity;
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID ==
                                          product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price*e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

