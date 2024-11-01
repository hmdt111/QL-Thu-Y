using Clinic_Animal_Project.ModelFromDB;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        CSDLClinicAnimal dbc;
        public ServiceController(CSDLClinicAnimal db)
        {
            dbc = db;
        }
        [HttpGet]
        [Route("/DichVu/List")]
        public IActionResult GetList()
        {
            var ser = dbc.Servicesses.ToList();
            return Ok(ser);
        }
    }
}
