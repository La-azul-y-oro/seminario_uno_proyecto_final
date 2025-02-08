using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IGenericService<Supplier, long> _supplierService;

        public SupplierController(IGenericService<Supplier, long> supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/supplier
        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> GetAll()
        {
            var suppliers = _supplierService.GetAll();
            return Ok(suppliers);
        }

        // GET: api/supplier/5
        [HttpGet("{cuit}")]
        public ActionResult<Supplier> GetByCuit(long cuit)
        {
            try
            {
                var supplier = _supplierService.GetById(cuit);
                return Ok(supplier);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/supplier
        [HttpPost]
        public ActionResult<Supplier> Create([FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest();
            }

            _supplierService.Create(supplier);
            return CreatedAtAction(nameof(GetByCuit), new { cuit = supplier.Cuit }, supplier);
        }

        // PUT: api/supplier/5
        [HttpPut("{cuit}")]
        public ActionResult Update(long cuit, [FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest();
            }

            try
            {
                _supplierService.Update(cuit, supplier);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/supplier/5
        [HttpDelete("{cuit}")]
        public ActionResult Delete(long cuit)
        {
            try
            {
                _supplierService.Delete(cuit);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
