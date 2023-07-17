using Microsoft.EntityFrameworkCore;

namespace BACK_CRUD_Mascota.Models.Repository
{
    public class PetRepository: IPetRepository
    {
        private readonly AplicationDbContext _context;

        public PetRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Add(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task DeletePet(Pet pet)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePet(Pet pet)
        {
            var mascotaItem = await _context.Pets.FirstOrDefaultAsync(p => p.Id == pet.Id);

            mascotaItem.Name = pet.Name;
            mascotaItem.Breed = pet.Breed;
            mascotaItem.Age = pet.Age;
            mascotaItem.Weight = pet.Weight;
            mascotaItem.Color = pet.Color;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Pet>> GetListPets()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _context.Pets.FindAsync(id);
        }




    }
}
