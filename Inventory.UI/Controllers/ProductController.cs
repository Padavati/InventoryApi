using Inventory.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.UI.Controllers
{ //to connect with API
    public class ProductController : Controller
    {
        private IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        { 
            _configuration = configuration;
        }
        public async Task<IActionResult> Index() //GetProducts
        {
            IEnumerable<Product> productResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Product/GetProducts";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                       var result=await response.Content.ReadAsStringAsync();
                        productResult=JsonConvert.DeserializeObject<IEnumerable<Product>>(result);   
                    }
                    
                }
            }
            
            return View(productResult);
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
                        ViewBag.message = "Product Details Saved Successfully!!";
                    }
                    else

                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entry!";
                    }
                }
            }
            return View();
        }
    }
}
