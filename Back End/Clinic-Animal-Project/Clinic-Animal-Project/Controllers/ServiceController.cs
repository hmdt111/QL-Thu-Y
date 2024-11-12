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
            try
            {
                var ser = dbc.Servicesses.ToList();
                if (ser.Count == 0)
                {
                    return NotFound("Service not available");
                }
                return Ok(ser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [Route("/DichVu/TimKiem/{id}")]
        public IActionResult TimKiem(int id)
        {
            try
            {
                var ser = dbc.Servicesses.Find(id);
                if (ser == null)
                {
                    return NotFound($"Service details not found with id {id}");
                }
                return Ok(ser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/DichVu/Insert")]
        public IActionResult ThemDichVu(Servicess ser)
        {
            try
            {
                dbc.Servicesses.Add(ser);
                dbc.SaveChanges();
                return Ok("Service created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut]
        [Route("/DichVu/Update")]
        public IActionResult CapNhatDichVu(Servicess ser)
        {
            if (ser == null || ser.ServiceId == 0)
            {
                if (ser == null)
                {
                    return BadRequest("Medication data is invalid");
                }
                else if (ser.ServiceId == 0)
                {
                    return BadRequest($"Medication Id {ser.ServiceId} is invalid");
                }
            }
            try
            {
                var service = dbc.Servicesses.Find(ser.ServiceId);
                if (service == null)
                {
                    return NotFound($"Service not found with id {ser.ServiceId}");
                }
                service.ServiceName = ser.ServiceName;
                service.UnitPrice = ser.UnitPrice;
                dbc.SaveChanges();

                return Ok("Service details update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("/DichVu/Delete/{id}")]
        public IActionResult XoaDichVu(int id)
        {
            try
            {
                var service = dbc.Servicesses.Find(id);
                if (service == null)
                {
                    return NotFound($"Service not found with id {id}");
                }

                dbc.Servicesses.Remove(service);
                dbc.SaveChanges();
                return Ok("Service detailed deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
