using Clinic_Animal_Project.ModelFromDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var medication = dbc.Medications.ToList();
            return Ok(medication);
        }

        [HttpPost]
        [Route("/Thuoc/Insert")]
        public IActionResult ThemThuoc(string name, decimal price,int stockQty,string des)
        {
            Medication m = new Medication();
            m.MedicationName = name;
            m.UnitPrice = price;
            m.StockQuantity = stockQty;
            m.MedicationDescription = des;

            dbc.Medications.Add(m);
            dbc.SaveChanges();
            return Ok(new { m });
        }

        [HttpPut]
        [Route("/Thuoc/Update")]
        public IActionResult CapNhatThuoc(int id, string name, decimal price,int stockQty,string des)
        {
            Medication m = new Medication();
            m.MedicationId = id;
            m.MedicationName = name;
            m.UnitPrice = price;
            m.StockQuantity = stockQty;
            m.MedicationDescription = des;

            dbc.Medications.Update(m);
            dbc.SaveChanges();
            return Ok(new { m });
        }

        [HttpDelete]
        [Route("/Thuoc/Delete")]
        public IActionResult XoaThuoc(int id)
        {
            Medication m = new Medication();
            m.MedicationId = id;

            dbc.Medications.Remove(m);
            dbc.SaveChanges();
            return Ok(new { m });
        }
    }
}
