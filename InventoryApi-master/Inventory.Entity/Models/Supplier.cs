using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entity.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }//Unique Id
        public string SupplierName { get; set; }
        public string SupplierEmail { get; set; }       
        public string SupplierCity { get; set; }
        public string SupplierState { get; set; }
        public string SupplierCountry { get; set; }
        public string SupplierPinCode { get; set; }

     
    }
}
