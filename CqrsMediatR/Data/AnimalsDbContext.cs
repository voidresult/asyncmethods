using Microsoft.EntityFrameworkCore;

namespace CqrsMediatR.Data
{
    public class AnimalsDbContext : DbContext
    {        
        public AnimalsDbContext(DbContextOptions<AnimalsDbContext> options) : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalKind> AnimalKinds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnimalKind>().HasData(
                new AnimalKind { Id = 1, Name = "Дикие" }, 
                new AnimalKind { Id = 2, Name = "Домашние" }
            );
            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Лев", AnimalKindId = 1 },
                new Animal { Id = 2, Name = "Кот", AnimalKindId = 2 },
                new Animal { Id = 3, Name = "Корова", AnimalKindId = 2 },
                new Animal { Id = 4, Name = "Скунс", AnimalKindId = 1 },
                new Animal { Id = 5, Name = "Овца", AnimalKindId = 2 },
                new Animal { Id = 6, Name = "Волк", AnimalKindId = 1 }
            );            
        }
    }
}
