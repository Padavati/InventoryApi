using Inventory.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.UI.Controllers
{
    public class OrderController : Controller
    {
        private IConfiguration _configuration;
        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region ShowOrderDetails
        public async Task<IActionResult> Index() //GetOrders
        {
            IEnumerable<Order> orderResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Order/GetOrders";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        orderResult = JsonConvert.DeserializeObject<IEnumerable<Order>>(result);
                    }

                }
            }

            return View(orderResult);
        }
        #endregion ShowOrderDetails
        #region AddOrderDetails
        public IActionResult OrderDetails()

        {
            return View();

        }

        //Add Order
        [HttpPost]
        public async Task<IActionResult> OrderDetails(Order order)

        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/Json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Order/AddOrder";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Order Details Saved Successfully!!";
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
        #endregion AddOrderDetails
        #region EditOrderDetails
        // GET Method
        public async Task<IActionResult> GetOrderDetails(int OrderId) //GetOrders
        {
            Order orderResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Order/GetOrderById?OrderId=" + OrderId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        orderResult = JsonConvert.DeserializeObject<Order>(result);
                    }

                }
            }

            return View(orderResult);
        }


        // POST Method
        [HttpPost]
        public async Task<IActionResult> GetOrderDetails(Order orderDetails)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(orderDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Order/UpdateOrder";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Updated Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View(orderDetails);
        }
        #endregion EditOrderDetails
        #region DeleteOrderDetails
        public async Task<IActionResult> DeleteOrderDetails(int OrderId)//Delete Order Details 
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Order/DeleteOrder?OrderId=" + OrderId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        ViewBag.message = "Deleted Successfully";
                    }
                }
            }
            return RedirectToAction("OrderId");

        }
        #endregion DeleteOrderDetails
    }
}
