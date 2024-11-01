using Clinic_Animal_Project.ModelFromDB;
using Clinic_Animal_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Clinic_Animal_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        CultureInfo culture = new CultureInfo("vi-VN");
        CSDLClinicAnimal dbc;
        public AccountController(CSDLClinicAnimal db)
        {
            dbc = db;
        }
        [HttpGet]
        [Route("/TaiKhoan/List")]
        public IActionResult GetList()
        {
            var accs = dbc.Accounts.Select(p => new AccountVM
            {
               AccountId = p.AccountId,
               Username = p.Username,
               Pass = p.Pass,
               EmployeeName = p.Employee.EmployeeName,
               CreatedAt = p.CreatedAt,
               LastLogin = p.LastLogin,
               
            });

            return Ok(accs);
        }
    }
}
