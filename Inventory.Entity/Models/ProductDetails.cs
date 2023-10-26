using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Inventory.Entity.Models
{
    public class ProductDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductDetailId { get; set; }
        public Product product {  get; set; }
        [ForeignKey("product")]
        public int ProductId { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
    }

    

    
}
