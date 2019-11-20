using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Entities;

namespace SMS.DataLayer
{
    public class SandwichContext : DbContext
    {
        public SandwichContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=SandwishDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<SandwichEF> Sandwiches { get; set; }
        public DbSet<IngredientEF> Ingredients { get; set; }
    }
}
