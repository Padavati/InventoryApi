using Inventory.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.UI.Controllers
{
    public class ProductController : Controller
    {
        private IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        { 
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            //to connect with API
            return View();
        }
        public IActionResult ProductDetails()
        
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ProductDetails(Product product)
        
       {
            ViewBag.status = "";
            using(HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/Json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Product/AddProduct";
                using(var response = await client.PostAsync(endpoint, content))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Product Details Saved Successfully";
                    }
                    else

                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Product Details Not Saved";
                    }
                }
            }
            return View();
        }
    }
}
