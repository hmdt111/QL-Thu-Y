using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}
