using Clinic_Animal_Project.ModelFromDB;
using Clinic_Animal_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        CSDLClinicAnimal dbc;
        public PetController(CSDLClinicAnimal db)
        {
            dbc = db;
        }
        [HttpGet]
        [Route("/ThuCung/List")]
        public IActionResult GetList()
        {
            var pets = dbc.Pets.Select(p => new PetVM
            {
               PetId = p.PetId,
               PetName = p.PetName,
               Breed = p.Breed,
               Species = p.Species,
               MedicalHistory = p.MedicalHistory,
               CustomerName = p.Customer.CustomerName
            });

            return Ok(pets);
        }
    }
}
