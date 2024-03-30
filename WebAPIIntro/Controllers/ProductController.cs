using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
 

        [HttpGet]
        public IActionResult GetAll() 
        {
            NorthwndContext db = new NorthwndContext();
            List<Product> products =db.Products.ToList();
            return Ok (products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            NorthwndContext db = new NorthwndContext();
            Product product = db.Products.FirstOrDefault(x => x.ProductId == id);

            if (product ==null)
            {
                return NotFound("Böyle bir Product mevcut değil");
            }
            return Ok (product);

        }


    }
}
