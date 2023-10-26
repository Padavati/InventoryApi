using Inventory.DAL.Data;
using Inventory.DAL.Repository;
using Inventory.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BAL.Services
{
    public class ProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //Add Product
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        //DeleteProduct
        public void DeleteProduct(int ProductId)
        {
            _productRepository.DeleteProduct(ProductId);
        }
        //GetProduct by Id
        public Product GetProductById(int ProductId)
        {
           return  _productRepository.GetProductById(ProductId);
        }
        //Get all products
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        //update the product
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

    }

}
