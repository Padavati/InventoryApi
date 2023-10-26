using Inventory.BAL.Services;
using Inventory.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private SupplierService _supplierService;
        public SupplierController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet("GetSuppliers")]
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _supplierService.GetSuppliers();
        }
        [HttpGet("GetSupplierById")]
        public Supplier GetSupplierById(int SupplierId)
        {
            return _supplierService.GetSupplierById(SupplierId);
        }
        [HttpDelete("DeleteSupplier")]
        public IActionResult DeleteSupplier(int SupplierId)
        {
            _supplierService.DeleteSupplier(SupplierId);
            return Ok("Supplier deleted Successfully");
        }
        [HttpPut("UpdateSupplier")]
        public IActionResult UpdateSupplier([FromBody] Supplier supplier)
        {
            _supplierService.UpdateSupplier(supplier);
            return Ok("Supplier updated successfully");
        }
        [HttpPost("AddSupplier")]
        public IActionResult AddSupplier([FromBody] Supplier supplier)
        {
            _supplierService.AddSupplier(supplier);
            return Ok("Supplier created successfully");
        }
    }
}
