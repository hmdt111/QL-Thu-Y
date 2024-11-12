using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Front_end.Controllers
{
    public class RoleController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7189/ChucVu");
        private readonly HttpClient _client;
        public RoleController() 
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<RoleViewModel>>(data);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel model)
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
                        TempData["successMessage"] = "Role Created.";
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
                RoleViewModel role = new RoleViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/TimKiem/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    role = JsonConvert.DeserializeObject<RoleViewModel>(data);
                }
                return View(role);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
        [HttpPost]
        public IActionResult Edit(RoleViewModel role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string data = JsonConvert.SerializeObject(role);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Update", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = "Role details updated.";
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
    }
}
