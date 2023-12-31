﻿using Inventory.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace Inventory.UI.Controllers
{ //to connect with API
    public class ProductController : Controller
    {
        private IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region ShowProductDetails
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
                        var result = await response.Content.ReadAsStringAsync();
                        productResult = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
                    }

                }
            }

            return View(productResult);
        }
        #endregion ShowProductDetails
        #region AddProductDetails
        public IActionResult ProductDetails()

        {
            return View();

        }
        
        //Add Product
        [HttpPost]
        public async Task<IActionResult> ProductDetails(Product product)

        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/Json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Product/AddProduct";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
        #endregion AddProductDetails
        #region EditProductDetails
        // GET Method
        public async Task<IActionResult> GetProductDetails(int ProductId) //GetProducts
        {
            Product productResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Product/GetProductById?ProductId=" + ProductId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        productResult = JsonConvert.DeserializeObject<Product>(result);
                    }

                }
            }

            return View(productResult);
        }


        // POST Method
        [HttpPost]
        public async Task<IActionResult> GetProductDetails(Product productDetails)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(productDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Product/UpdateProduct";
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
            return View();
        }
        #endregion EditProductDetails
        #region DeleteProductDetails
        public async Task<IActionResult> DeleteProductDetails(int ProductId)//Delete Product Details 
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Product/DeleteProduct?ProductId=" + ProductId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        ViewBag.message = "Deleted Successfully";
                    }
                }
            }
            return RedirectToAction("ProductId");

        }
        #endregion DeleteProductDetails
    }

}
