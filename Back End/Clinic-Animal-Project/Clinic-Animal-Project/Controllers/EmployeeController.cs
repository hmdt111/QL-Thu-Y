using Clinic_Animal_Project.ModelFromDB;
using Clinic_Animal_Project.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        CSDLClinicAnimal dbc;
        public EmployeeController(CSDLClinicAnimal db) 
        {
            dbc = db;
        }
        [HttpGet]
        [Route("/NhanVien/List")]
        public IActionResult GetList()
        {
            var employees = dbc.Employees.Select(p => new EmployeeVM
            {
                EmployeeId = p.EmployeeId,
                EmployeeName = p.EmployeeName,
                PhoneNumber = p.PhoneNumber,
                EmployeeEmail = p.EmployeeEmail,
                HireDate = p.HireDate,
                RoleName =p.Role.RoleName  
            });
            
            return Ok(employees); 
        }

        [HttpPost]
        [Route("/NhanVien/Insert")]
        public IActionResult ThemNhanVien(string name,string phoneNumber,string email,/*DateOnly hireDate,*/int roleId)
        {
            Employee e = new Employee();
            e.EmployeeName = name;
            e.PhoneNumber = phoneNumber;
            e.EmployeeEmail = email;
            e.HireDate = DateOnly.FromDateTime(DateTime.Now);
            e.RoleId = roleId;
            dbc.Employees.Add(e);
            dbc.SaveChanges();
            return Ok(new { e });
        }

        [HttpPut]
        [Route("/NhanVien/Update")]
        public IActionResult CapNhatNhanVien(int id ,string name, string phoneNumber, string email, DateOnly hireDate, int roleId)
        {
            Employee e = new Employee();
            e.EmployeeId = id;
            e.EmployeeName = name;
            e.PhoneNumber = phoneNumber;
            e.EmployeeEmail = email;
            e.HireDate = hireDate;
            e.RoleId = roleId;
            dbc.Employees.Update(e);
            dbc.SaveChanges();
            return Ok(new { e });
        }

        [HttpDelete]
        [Route("/NhanVien/Delete")]
        public IActionResult XoaNhanVien(int id)
        {
            Employee e = new Employee();
            e.EmployeeId = id;
           
            dbc.Employees.Remove(e);
            dbc.SaveChanges();
            return Ok(new { e });
        }

    }


}
