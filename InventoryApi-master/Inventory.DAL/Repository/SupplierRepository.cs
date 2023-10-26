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
    public class SupplierRepository:ISupplierRepository
    {
        ProductDbContext _productDbContext;
        public SupplierRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public void AddSupplier(Supplier supplier)
        {
            _productDbContext.suppliers.Add(supplier);
            _productDbContext.SaveChanges();
        }

        public void DeleteSupplier(int SupplierId)
        {
            var supplier = _productDbContext.suppliers.Find(SupplierId);
            _productDbContext.suppliers.Remove(supplier);
            _productDbContext.SaveChanges();
        }

        public Supplier GetSupplierById(int SupplierId)
        {
            return _productDbContext.suppliers.Find(SupplierId);
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _productDbContext.suppliers.ToList();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _productDbContext.Entry(supplier).State = EntityState.Modified;
            _productDbContext.SaveChanges();
        }
    }
}
