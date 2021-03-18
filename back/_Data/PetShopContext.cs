using back._Models;
using Microsoft.EntityFrameworkCore;

namespace back._Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> option) : base(option) {}

        public DbSet<Alojamento> Alojamentos {get; set;}
        public DbSet<Animal> Animais { get; set; }
        public DbSet<DonoAnimal> DonosAnimais { get; set; }
        
    }
}