using api.Dto;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/supplier
        [HttpGet]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<IEnumerable<Supplier>> GetAll()
        {
            var suppliers = _supplierService.GetAll();
            return Ok(suppliers);
        }

        // GET: api/supplier/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
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
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult<Supplier> Create([FromBody] SupplierRequestDTO supplierDto)
        {
            if (supplierDto == null)
            {
                return BadRequest();
            }

            var supplier = _supplierService.Create(supplierDto);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
        }

        // PUT: api/supplier/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
        public ActionResult Update(int id, [FromBody] SupplierRequestDTO supplierDto)
        {
            if (supplierDto == null)
            {
                return BadRequest();
            }

            try
            {
                _supplierService.Update(id, supplierDto);
                return Ok();  
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/supplier/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN,STAFF")]
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
