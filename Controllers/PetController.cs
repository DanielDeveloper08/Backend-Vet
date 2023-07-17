using AutoMapper;
using BACK_CRUD_Mascota.Models;
using BACK_CRUD_Mascota.Models.DTO;
using BACK_CRUD_Mascota.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACK_CRUD_Mascota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IPetRepository _petRepository;

        public PetController(IMapper mapper, IPetRepository petRepository)
        {
            _mapper = mapper;
            _petRepository = petRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //Thread.Sleep(2000);
                var listPet = await _petRepository.GetListPets();
                var petDTO = _mapper.Map<IEnumerable<Pet>>(listPet);

                return Ok(listPet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pet = await _petRepository.GetPetById(id);

                if (pet == null)
                {
                    return NotFound();
                }

                var petDTO = _mapper.Map<PetDTO>(pet);

                return Ok(petDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pet = await _petRepository.GetPetById(id);

                if (pet == null)
                {
                    return NotFound();
                }

                await _petRepository.DeletePet(pet); 

                return NoContent();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PetDTO petDTO)
        {
            try
            {
                var mascota = _mapper.Map<Pet>(petDTO);

                mascota.CreationDate = DateTime.Now;
                
                mascota = await _petRepository.AddPet(mascota);

                var varItemPetDTO = _mapper.Map<PetDTO>(mascota);

                return CreatedAtAction("Get", new { id = varItemPetDTO.Id }, varItemPetDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PetDTO petDTO)
        {
            try
            {
                var mascota = _mapper.Map<Pet>(petDTO);

                if (id != mascota.Id)
                {
                    return BadRequest();
                }

                var mascotaItem = _petRepository.GetPetById(id);

                if (mascotaItem == null)
                {
                    return NotFound();
                }

                await _petRepository.UpdatePet(mascota);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }




    }
}
