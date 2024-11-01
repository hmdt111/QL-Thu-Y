using Clinic_Animal_Project.ModelFromDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        CSDLClinicAnimal dbc;
        public RoleController(CSDLClinicAnimal db)
        {
            dbc = db;
        }
        [HttpGet]
        [Route("/ChucVu/List")]
        public IActionResult GetList()
        {
            var roles = dbc.Roles.ToList();
            return Ok(roles);
        }
        [HttpPost]
        [Route("/ChucVu/Insert")]
        public IActionResult ThemChucVu(string name, string des)
        {
            Role r = new Role();
            r.RoleName = name;
            r.RoleDescription = des;
            
            dbc.Roles.Add(r);
            dbc.SaveChanges();
            return Ok(new { r });
        }

        [HttpPut]
        [Route("/ChucVu/Update")]
        public IActionResult CapNhatChucVu(int id,string name, string des)
        {
            Role r = new Role();
            r.RoleId = id;
            r.RoleName = name;
            r.RoleDescription = des;

            dbc.Roles.Update(r);
            dbc.SaveChanges();
            return Ok(new { r });
        }

        [HttpDelete]
        [Route("/ChucVu/Delete")]
        public IActionResult XoaChucVu(int id)
        {
            Role r = new Role();
            r.RoleId = id;
            
            dbc.Roles.Remove(r);
            dbc.SaveChanges();
            return Ok(new { r });
        }
    }
}
