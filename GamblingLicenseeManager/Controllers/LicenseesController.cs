using GamblingLicenseeManager.Models;
using GamblingLicenseeManager.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamblingLicenseeManager.Controllers
{
    // Controllers/LicenseesController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseesController : ControllerBase
    {
        private readonly ILicenseeRepository _licenseeRepository;
        private readonly IProductRepository _productRepository;

        public LicenseesController(ILicenseeRepository licenseeRepository, IProductRepository productRepository)
        {
            _licenseeRepository = licenseeRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_licenseeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var licensee = _licenseeRepository.GetById(id);
            if (licensee == null)
            {
                return NotFound();
            }
            return Ok(licensee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Licensee licensee)
        {
            _licenseeRepository.Add(licensee);
            return CreatedAtAction(nameof(Get), new { id = licensee.Id }, licensee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Licensee licensee)
        {
            if (id != licensee.Id)
            {
                return BadRequest();
            }
            _licenseeRepository.Update(licensee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _licenseeRepository.Delete(id);
            return NoContent();
        }
    }



}
