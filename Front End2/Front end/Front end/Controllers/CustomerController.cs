using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Front_end.Controllers
{
    public class CustomerController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7189/KhachHang");
        private readonly HttpClient _client;

        public CustomerController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<CustomerViewModel> list = new List<CustomerViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<CustomerViewModel>>(data);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    string data = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Insert", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = "Customer Created.";
                        return RedirectToAction("Index");
                    }
                }
               
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {

                CustomerViewModel cus = new CustomerViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TimKiem/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    cus = JsonConvert.DeserializeObject<CustomerViewModel>(data);
                }
                return View(cus);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public IActionResult Edit(CustomerViewModel cus)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    string data = JsonConvert.SerializeObject(cus);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Update", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = "Customer details updated.";
                        return RedirectToAction("Index");
                    }
                }

               
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                CustomerViewModel cus = new CustomerViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TimKiem/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    cus = JsonConvert.DeserializeObject<CustomerViewModel>(data);
                }
                return View(cus);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Delete/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Medication details deleted.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
