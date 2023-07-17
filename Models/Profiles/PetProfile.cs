using AutoMapper;
using BACK_CRUD_Mascota.Models.DTO;

namespace BACK_CRUD_Mascota.Models.Profiles
{
    public class PetProfile:Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetDTO>();
            CreateMap<PetDTO, Pet>();
        }
    }
}
