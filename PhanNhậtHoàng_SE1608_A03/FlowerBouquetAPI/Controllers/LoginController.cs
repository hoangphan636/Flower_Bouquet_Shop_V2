using BusinessObject.Repository;
using BussinessObject.DataAccess;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerBouquetAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        CustomerRepository customer = new CustomerRepository();
        private readonly LoginDAO _jWTManager;

        public LoginController(LoginDAO jWTManager)
        {
            _jWTManager = jWTManager;
        }

        [HttpGet]
        
        public ActionResult<IEnumerable<Customer>> GetProducts() => customer.GetCustomer();

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(Login usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }


        [HttpPost("Register")]
        public ActionResult PostProduct(Customer p)
        {
            var check = customer.FindCustomerByEmail(p.Email);
            if (check == null)
            {
                customer.SaveCustomer(p);
                return Ok();
            }

            return NotFound();
        }



    }
}
