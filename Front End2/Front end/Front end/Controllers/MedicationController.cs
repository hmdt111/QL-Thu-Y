using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_end.Controllers
{
    public class MedicationController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7189/Thuoc");
        private readonly HttpClient _client;

        public MedicationController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<MedicationViewModel> list = new List<MedicationViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress +"/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<MedicationViewModel>>(data);
            }
            return View(list);
        }
    }
}
