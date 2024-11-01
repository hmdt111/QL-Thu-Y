using Clinic_Animal_Project.ModelFromDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CSDLClinicAnimal dbc;
        public CustomerController(CSDLClinicAnimal db)
        {
            dbc = db;
        }

        [HttpGet]
        [Route("/KhachHang/List")]
        public IActionResult GetList()
        {
            var cus = dbc.Customers.ToList();
            return Ok(cus);
        }

        [HttpPost]
        [Route("/KhachHang/Insert")]
        public IActionResult ThemKhachHang(string name, string phoneNumber, string address, string email)
        {
            Customer cus = new Customer();
            cus.CustomerName = name;
            cus.PhoneNumber = phoneNumber;
            cus.CustomerAddress = address;
            cus.CustomerEmail = email;

            dbc.Customers.Add(cus);
            dbc.SaveChanges();
            return Ok(new { cus });
        }

        [HttpPut]
        [Route("/KhachHang/Update")]
        public IActionResult CapNhatKhachHang(int id, string name, string phoneNumber, string address, string email)
        {
            Customer cus = new Customer();
            cus.CustomerId = id;
            cus.CustomerName = name;
            cus.PhoneNumber = phoneNumber;
            cus.CustomerAddress = address;
            cus.CustomerEmail = email;

            dbc.Customers.Update(cus);
            dbc.SaveChanges();
            return Ok(new { cus });
        }

        [HttpDelete]
        [Route("/KhachHang/Delete")]
        public IActionResult XoaKhachHang(int id)
        {
            Customer cus = new Customer();
            cus.CustomerId = id;

            dbc.Customers.Remove(cus);
            dbc.SaveChanges();
            return Ok(new { cus });
        }
    }
}
