using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_end.Controllers
{
    public class PetController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7189/ThuCung");
        private readonly HttpClient _client;

        public PetController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<PetViewModel> list = new List<PetViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/List").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<PetViewModel>>(data);
            }
            return View(list);
        }
    }
}
