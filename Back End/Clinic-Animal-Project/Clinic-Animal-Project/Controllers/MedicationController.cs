using Clinic_Animal_Project.ModelFromDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        CSDLClinicAnimal dbc;
        public MedicationController(CSDLClinicAnimal db)
        {
            dbc = db;
        }

        [HttpGet]
        [Route("/Thuoc/List")]
        public IActionResult GetList()
        {
            try
            {
                var medication = dbc.Medications.ToList();
                if (medication.Count == 0)
                {
                    return NotFound("Medication not available");
                }
                return Ok(medication);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet()]
        [Route("/Thuoc/TimKiem/{id}")]
        public IActionResult TimKiem(int id)
        {
            try
            {
                var medication = dbc.Medications.Find(id);
                if (medication == null)
                {
                    return NotFound($"Medication details not found with id {id}");
                }
                return Ok(medication);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("/Thuoc/Insert")]
        public IActionResult ThemThuoc(Medication med)
        {
            try
            {
                dbc.Medications.Add(med);
                dbc.SaveChanges();
                return Ok("Medication created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPut]
        [Route("/Thuoc/Update")]
        public IActionResult CapNhatThuoc(Medication med)
        {
            if (med == null || med.MedicationId == 0)
            {
                if(med == null)
                {
                    return BadRequest("Medication data is invalid");
                }else if (med.MedicationId == 0)
                {
                    return BadRequest($"Medication Id {med.MedicationId} is invalid");
                }
            }
            try
            {
                var medication = dbc.Medications.Find(med.MedicationId);
                if (medication == null)
                {
                    return NotFound($"Medication not found with id {med.MedicationId}");
                }
                medication.MedicationName = med.MedicationName;
                medication.UnitPrice = med.UnitPrice;
                medication.StockQuantity = med.StockQuantity;
                medication.MedicationDescription = med.MedicationDescription;
                dbc.SaveChanges();

                return Ok("Medication details update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("/Thuoc/Delete/{id}")]
        public IActionResult XoaThuoc(int id)
        {
            try
            {
                var medication = dbc.Medications.Find(id);
                if (medication == null)
                {
                    return NotFound($"Medication not found with id {id}");
                }

                dbc.Medications.Remove(medication);
                dbc.SaveChanges();
                return Ok("Medication detailed deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
