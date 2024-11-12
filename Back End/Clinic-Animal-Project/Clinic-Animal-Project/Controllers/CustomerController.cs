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
        [HttpGet()]
        [Route("/KhachHang/TimKiem/{id}")]
        public IActionResult TimKiem(int id)
        {
            try
            {
                var cus = dbc.Customers.Find(id);
                if (cus == null)
                {
                    return NotFound($"Product details not found with id {id}");
                }
                return Ok(cus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/KhachHang/Insert")]
        public IActionResult ThemKhachHang(Customer cus)
        {

            try
            {
                dbc.Customers.Add(cus);
                dbc.SaveChanges();
                return Ok("Customer created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/KhachHang/Update")]
        public IActionResult CapNhatKhachHang(Customer cus)
        {
            if (cus == null || cus.CustomerId == 0)
            {
                if (cus == null)
                {
                    return BadRequest("Customer data is invalid");
                }
                else if (cus.CustomerId == 0)
                {
                    return BadRequest($"Customer Id {cus.CustomerId} is invalid");
                }
            }
            try
            {
                var customer = dbc.Customers.Find(cus.CustomerId);
                if (customer == null)
                {
                    return NotFound($"Medication not found with id {cus.CustomerId}");
                }
                customer.CustomerName=cus.CustomerName;
                customer.CustomerEmail=cus.CustomerEmail;
                customer.PhoneNumber=cus.PhoneNumber;
                customer.CustomerAddress=cus.CustomerAddress;
                dbc.SaveChanges();

                return Ok("Customer details update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/KhachHang/Delete/{id}")]
        public IActionResult XoaKhachHang(int id)
        {
            try
            {
                var customer = dbc.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound($"Medication not found with id {id}");
                }

                dbc.Customers.Remove(customer);
                dbc.SaveChanges();
                return Ok("Customer detailed deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
