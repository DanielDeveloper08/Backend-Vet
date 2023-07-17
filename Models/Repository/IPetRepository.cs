namespace BACK_CRUD_Mascota.Models.Repository
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetListPets();

        Task<Pet> GetPetById(int id);

        Task DeletePet(Pet pet);

        Task<Pet> AddPet(Pet pet);

        Task UpdatePet(Pet pet);
    }
}
