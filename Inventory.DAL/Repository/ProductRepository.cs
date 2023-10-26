using Inventory.DAL.Data;
using Inventory.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public void AddProduct(Product product)
        {
            _productDbContext.products.Add(product);
            _productDbContext.SaveChanges();
        }

        public void DeleteProduct(int ProductId)
        {
            var product = _productDbContext.products.Find(ProductId);
            _productDbContext.products.Remove(product);
            _productDbContext.SaveChanges();
        }

        public Product GetProductById(int ProductId)
        {
            return _productDbContext.products.Find(ProductId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productDbContext.products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            _productDbContext.Entry(product).State = EntityState.Modified;
            _productDbContext.SaveChanges();
        }
    }
}
