using Inventory.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.UI.Controllers
{
    public class SupplierController : Controller
    {
        private IConfiguration _configuration;
        public SupplierController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region ShowSupplierDetails
        public async Task<IActionResult> Index() //GetSuppliers
        {
            IEnumerable<Supplier> supplierResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Supplier/GetSuppliers";
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        supplierResult = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(result);
                    }

                }
            }

            return View(supplierResult);
        }
        #endregion ShowSupplierDetails
        #region AddSupplierDetails
        public IActionResult SupplierDetails()

        {
            return View();

        }

        //Add Supplier
        [HttpPost]
        public async Task<IActionResult> SupplierDetails(Supplier supplier)

        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(supplier), Encoding.UTF8, "application/Json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Supplier/AddSupplier";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "OK";
                        ViewBag.message = "Supplier Details Saved Successfully!!";
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
        #endregion AddSupplierDetails
        #region EditSupplierDetails
        // GET Method
        public async Task<IActionResult> GetSupplierDetails(int SupplierId) //GetSuppliers
        {
            Supplier supplierResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiBaseUrl"] + "Supplier/GetSupplierById?SupplierId=" + SupplierId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        supplierResult = JsonConvert.DeserializeObject<Supplier>(result);
                    }

                }
            }

            return View(supplierResult);
        }


        // POST Method
        [HttpPost]
        public async Task<IActionResult> GetSupplierDetails(Supplier supplierDetails)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(supplierDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Supplier/UpdateSupplier";
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
            return View(supplierDetails);
        }
        #endregion EditSupplierDetails
        #region DeleteSupplierDetails
        public async Task<IActionResult> DeleteSupplierDetails(int SupplierId)//Delete Supplier Details 
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Supplier/GetSupplierById?SupplierId=" + SupplierId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        ViewBag.message = "Deleted Successfully";
                    }
                }
            }
            return RedirectToAction("SupplierId");

        }
        #endregion DeleteSupplierDetails
    }
}
