using BACK_CRUD_Mascota.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACK_CRUD_Mascota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public PetController(AplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //Thread.Sleep(2000);
                var listPet = await _context.Pets.ToListAsync();
                return Ok(listPet);
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }
    }
}
