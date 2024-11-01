using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_end.Controllers
{
    public class ServiceController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7189/DichVu");
        private readonly HttpClient _client;
        public ServiceController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ServiceViewModel> list = new List<ServiceViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<ServiceViewModel>>(data);
            }
            return View(list);
        }
    }
}
