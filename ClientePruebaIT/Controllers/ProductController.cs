using ClientePruebaIT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Text.Json;

namespace ClientePruebaIT.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var products = await client.GetFromJsonAsync<List<Product>>("https://localhost:7182/api/Products");
            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var client = new HttpClient();
            return View(await client.GetFromJsonAsync<Product>("https://localhost:7182/api/Products/" + id.ToString()));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            var client = new HttpClient();
            try
            {
                var data = JsonSerializer.Serialize<Product>(product);
                var response =  client.PostAsync("https://localhost:7182/api/Products", new StringContent(data, Encoding.UTF8, "application/json"));
                if (response.IsCompletedSuccessfully)
                {
                    // Read the response content
                    
                }
                else
                {
                    Console.WriteLine($"Error: {response}");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var client = new HttpClient();
            return View(await client.GetFromJsonAsync<Product>("https://localhost:7182/api/Products/" + id.ToString()));
            //return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                var client = new HttpClient();
                var data = JsonSerializer.Serialize<Product>(product);
                var response = client.PutAsync("https://localhost:7182/api/Products/" + id.ToString(), new StringContent(data, Encoding.UTF8, "application/json"));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        /*public ActionResult Delete(int id)
        {
            var client = new HttpClient();
            return View(client.GetFromJsonAsync<Product>("https://localhost:7182/api/Products/" + id.ToString()));
            //return View();
        }*/

        // POST: ProductController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var client = new HttpClient();
                var result = await client.DeleteAsync("https://localhost:7182/api/Products/" + id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
