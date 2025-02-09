using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IGenericService<Supplier, int> _supplierService;

        public SupplierController(IGenericService<Supplier, int> supplierService)
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
        [HttpGet("{id}")]
        public ActionResult<Supplier> GetById(int id)
        {
            try
            {
                var supplier = _supplierService.GetById(id);
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
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
        }

        // PUT: api/supplier/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest();
            }

            try
            {
                _supplierService.Update(id, supplier);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/supplier/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _supplierService.Delete(id);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
