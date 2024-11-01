using Clinic_Animal_Project.ModelFromDB;
using Clinic_Animal_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        CSDLClinicAnimal dbc;
        public AppointmentController(CSDLClinicAnimal db)
        {
            dbc = db;
        }
        [HttpGet]
        [Route("/LichHen/List")]
        public IActionResult GetList()
        {
            var apps = dbc.Appointments.Select(p => new AppointmentVM
            {
                AppointmentId = p.AppointmentId,
                AppointmentDate = p.AppointmentDate,
                CustomerName = p.Customer.CustomerName,
                EmployeeName = p.Employee.EmployeeName,
                PetName = p.Pet.PetName,
                ServiceName = p.Service.ServiceName,
                Note = p.Note,
            });

            return Ok(apps);
        }
    }
}
