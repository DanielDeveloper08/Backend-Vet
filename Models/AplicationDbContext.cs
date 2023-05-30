using Microsoft.EntityFrameworkCore;

namespace BACK_CRUD_Mascota.Models
{
    public class AplicationDbContext: DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) { }

        public DbSet<Pet> Pets { get; set; }
    }
}
