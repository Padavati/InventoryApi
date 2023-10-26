using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entity.Models
{
    public  class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }//Unique Id
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
