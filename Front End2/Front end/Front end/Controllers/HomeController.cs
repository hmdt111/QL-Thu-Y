using Animal_clinic_project.Models;
using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Animal_clinic_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Uri baseAddress = new Uri("https://localhost:7189/DichVu");
       
        private readonly HttpClient _client;
       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
       
       

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
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

        public IActionResult About()
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
