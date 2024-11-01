using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}
