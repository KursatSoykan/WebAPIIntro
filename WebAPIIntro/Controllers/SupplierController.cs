using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            NorthwndContext db = new NorthwndContext();
            List<Supplier> suppliers = db.Suppliers.ToList();
            return Ok(suppliers);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            NorthwndContext db = new NorthwndContext();
            Supplier supplier = db.Suppliers.FirstOrDefault(x => x.SupplierId == id);

            if (supplier == null)
            {
                return NotFound("Böyle bir Supplier mevcut değil");
            }
            return Ok(supplier);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            NorthwndContext ctx = new NorthwndContext();
            Supplier supplier = ctx.Suppliers.FirstOrDefault(y => y.SupplierId == id);
           
            if (supplier == null) 
            {
                return NotFound("Böyle bir Supplier bulunamadı");
            }

            ctx.Suppliers.Remove(supplier);
            ctx.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Supplier supplier) 
        {
            NorthwndContext context = new NorthwndContext();
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return Ok();
  
        }
        [HttpPut]
        public IActionResult Update(Supplier supplier) 
        {
            NorthwndContext context = new NorthwndContext();
            Supplier supplier1 = context.Suppliers.FirstOrDefault(y=> y.SupplierId == supplier.SupplierId); 

            supplier1.ContactName = supplier.ContactName;
            supplier1.Phone = supplier.Phone;
            supplier1.CompanyName = supplier.CompanyName;

            context.SaveChanges();
            return Ok("Güncelleme Başarılı");
        
        
        
        }

    }     

}