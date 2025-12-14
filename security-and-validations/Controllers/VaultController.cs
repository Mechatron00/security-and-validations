using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using security_and_validations.Data;
using security_and_validations.Models;

namespace security_and_validations.Controllers
{

    [ApiController]
    [Route("api/vault")]
    public class VaultController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VaultController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Create(VaultItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.VaultItems.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.VaultItems.ToList());
        }
    }
}

