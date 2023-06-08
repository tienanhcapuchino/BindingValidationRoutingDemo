using BindingValidationRoutingDemo.DTO;
using BindingValidationRoutingDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindingValidationRoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public NorthwindContext context;
/*
        [BindProperty(SupportsGet = true)]
        public EmployeeDTO employee { get; set; }*/

       public EmployeeController(NorthwindContext _context) {
           context= _context;
        
        
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployeeById()
        {
            int id = int.Parse(Request.Query["eid"]);
            Employee e = context.Employees.FirstOrDefault(x => x.EmployeeId== id);
            return Ok(e);
        }


        [HttpPost("addList")]
        public IActionResult AddListEmployee( List<EmployeeDTO> ems)
        {
            return Ok();
        }

        [HttpGet("addOne")]
        public IActionResult AddOneEmployee( [FromForm]EmployeeDTO e )
        {
            string s = e.LastName;
            return Ok(s);
        }

        [HttpPost("getFromForm/{eid}")]
        public IActionResult GetEmployee([FromBody] int eid)
        {
            Employee e = context.Employees.FirstOrDefault(x => x.EmployeeId == eid);
            string s = $"From body {e.EmployeeId} - {e.LastName} - {e.FirstName}";
            return Ok(s);
        }


        [HttpPost("login")]
        public IActionResult Login([FromHeader] string username, [FromHeader] string password)
        {
           if(username.Equals("VietLBHE153765") && password.Equals("123"))
            {
                return Ok("Login successful");
            }
           
           return NotFound();
        }


        [HttpGet("custom/{id}")]
        public IActionResult EmployeeDetail([ModelBinder(Name = "Id")] EmployeeDTO emp)
        {
            return Ok(emp);
        }

        [HttpPost("modelstate")]
        public IActionResult validationUsingModelState ([FromForm]EmployeeDTO e)
        {
            if (string.IsNullOrEmpty(e.Title)){

                ModelState.AddModelError("Title", "Title must be not empty");
            }
            if (!ModelState.IsValid)
            {
                // Xử lý khi có lỗi validation
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(errors);
            }
            return Ok(e);
        }


    }
}
