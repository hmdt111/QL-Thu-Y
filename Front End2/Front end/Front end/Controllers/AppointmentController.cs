using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_end.Controllers
{
    public class AppointmentController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7189/LichHen");
        private readonly HttpClient _client;

        public AppointmentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AppointmentViewModel> list = new List<AppointmentViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(data);
            }
            return View(list);
        }

       

    }
}
