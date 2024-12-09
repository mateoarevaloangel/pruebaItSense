using AspMVCPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AspMVCPrueba.Controllers
{
    public class ProductController : Controller
    {

        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var products = await client.GetFromJsonAsync<List<ProductModel>>("https://localhost:7182/api/Products");
            return View(products);
        }

        // GET: ProductController
        public async Task<ActionResult> envioPostAsync()
        {
            ProductModel product = new ProductModel();
            product.Name = Convert.ToString(Request.Query["Name"]);
            product.Stock = Convert.ToInt32(Request.Query["Stock"]);
            //product.Status = Convert.ToBoolean(Request.Query["Status"]);
            var client = new HttpClient();
            
            var data = JsonSerializer.Serialize<ProductModel>(product);
            var response = await client.PostAsync("https://localhost:7182/api/Products", new StringContent(data, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                string content2 = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content2);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
            return Redirect(nameof(Index));
        }
        public async Task<ActionResult> envioPutAsync()
        {
            ProductModel product = new ProductModel();
            product.Name = Convert.ToString(Request.Query["Name"]);
            product.Stock = Convert.ToInt32(Request.Query["Stock"]);
            //product.Status = Convert.ToBoolean(Request.Query["Status"]);
            var client = new HttpClient();

            var data = JsonSerializer.Serialize<ProductModel>(product);
            var response = await client.PutAsync("https://localhost:7182/api/Products", new StringContent(data, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                string content2 = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content2);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
            return Redirect(nameof(Index));
        }
        public async Task<ActionResult> envioEditAsync()
        {
            ProductModel product = new ProductModel();
            product.Name = Convert.ToString(Request.Query["Name"]);
            product.Stock = Convert.ToInt32(Request.Query["Stock"]);
            //product.Status = Convert.ToBoolean(Request.Query["Status"]);
            var client = new HttpClient();

            var data = JsonSerializer.Serialize<ProductModel>(product);
            var response = await client.PutAsync("https://localhost:7182/api/Products/2", new StringContent(data, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                string content2 = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content2);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
            return Redirect(nameof(Index));
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> EditProduct(int id)
        {
            var client = new HttpClient();
            var model = await client.GetFromJsonAsync<ProductModel>("https://localhost:7182/api/Products/"+id.ToString());
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
