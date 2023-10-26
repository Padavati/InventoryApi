using Inventory.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Repository
{
    public interface ISupplierRepository
    {
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int SupplierId);
        Supplier GetSupplierById(int SupplierId);
        IEnumerable<Supplier> GetSuppliers();
    }
}
