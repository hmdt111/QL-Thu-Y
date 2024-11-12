using Clinic_Animal_Project.ModelFromDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

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
            try
            {
                var role = dbc.Roles.ToList();
                if (role.Count == 0)
                {
                    return NotFound("Role not available");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet()]
        [Route("/ChucVu/TimKiem/{id}")]
        public IActionResult TimKiem(int id)
        {
            try
            {
                var role = dbc.Roles.Find(id);
                if (role == null)
                {
                    return NotFound($"Service details not found with id {id}");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/ChucVu/Insert")]
        public IActionResult ThemChucVu(Role role)
        {
            try
            {
                dbc.Roles.Add(role);
                dbc.SaveChanges();
                return Ok("Service created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/ChucVu/Update")]
        public IActionResult CapNhatChucVu(Role role)
        {
            if (role == null || role.RoleId == 0)
            {
                if (role == null)
                {
                    return BadRequest("Role data is invalid");
                }
                else if (role.RoleId == 0)
                {
                    return BadRequest($"Role Id {role.RoleId} is invalid");
                }
            }
            try
            {
                var ro = dbc.Roles.Find(role.RoleId);
                if (ro == null)
                {
                    return NotFound($"Service not found with id {role.RoleId}");
                }
                ro.RoleName = role.RoleName;
                ro.RoleDescription = role.RoleDescription;
                dbc.SaveChanges();

                return Ok("Service details update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/ChucVu/Delete/{id}")]
        public IActionResult XoaChucVu(int id)
        {
            try
            {
                var role = dbc.Roles.Find(id);
                if (role == null)
                {
                    return NotFound($"Role not found with id {id}");
                }

                dbc.Roles.Remove(role);
                dbc.SaveChanges();
                return Ok("Role detailed deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
