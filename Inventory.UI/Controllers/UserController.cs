using Inventory.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.UI.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfo userInfo)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/Json");
                string endpoint = _configuration["WebApiBaseUrl"] + "User/Register";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Registered Successfully!!";
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(UserInfo userInfo)
        {
            ViewBag.status = "";


            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/Json");
                string endpoint = _configuration["WebApiBaseUrl"] + "User/Login";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong credentials!";
                    }
                }
            }
            return View();
        }
    }
}
