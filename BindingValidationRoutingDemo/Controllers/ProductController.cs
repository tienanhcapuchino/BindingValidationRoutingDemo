using BindingValidationRoutingDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BindingValidationRoutingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        public ProductController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            return Ok(_northwindContext.Products.Include(x => x.Category).Select(x => new
            {
                x.ProductName,
                x.ProductId,
                x.Category.CategoryName,
                x.Discontinued,
                x.UnitPrice,
                x.UnitsInStock,
                x.ReorderLevel
            }).ToList());
        }
    }
}
