using Inventory.DAL.Repository;
using Inventory.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BAL.Services
{
    public class SupplierService
    {
        ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        //Add Supplier
        public void AddSupplier(Supplier supplier)
        {
            _supplierRepository.AddSupplier(supplier);
        }
        //Delete Supplier
        public void DeleteSupplier(int SupplierId)
        {
            _supplierRepository.DeleteSupplier(SupplierId);
        }
        //Get Supplier by Id
        public Supplier GetSupplierById(int SupplierId)
        {
            return _supplierRepository.GetSupplierById(SupplierId);

        }
        //Get all Supplier
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _supplierRepository.GetSuppliers();
        }
        //update the Supplier
        public void UpdateSupplier(Supplier supplier)
        {
            _supplierRepository.UpdateSupplier(supplier);
        }
    }
}
