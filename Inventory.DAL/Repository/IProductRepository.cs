using Inventory.Entity.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Repository
{
    public interface IProductRepository
    {

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int ProductId);
        Product GetProductById(int ProductId);
        IEnumerable<Product> GetProducts();



    }
}
