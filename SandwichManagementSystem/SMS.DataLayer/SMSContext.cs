using Microsoft.EntityFrameworkCore;
using SMS.DataLayer.Entities;

namespace SMS.DataLayer
{
    public class SMSContext : DbContext
    {
        public SMSContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SandwichIngredientEF>().HasKey(si => new { si.SandwichId, si.IngredientId });

            modelBuilder.Entity<SandwichIngredientEF>()
                .HasOne<SandwichEF>(s => s.Sandwich)
                .WithMany(s => s.SandwichIngredients)
                .HasForeignKey(si => si.SandwichId);

            modelBuilder.Entity<SandwichIngredientEF>()
                .HasOne<IngredientEF>(i => i.Ingredient)
                .WithMany(i => i.SandwichIngredients)
                .HasForeignKey(si => si.IngredientId);
        }

        public DbSet<SupplierEF> Suppliers { get; set; }
        public DbSet<SandwichEF> Sandwiches { get; set; }
        public DbSet<IngredientEF> Ingredients { get; set; }
        public DbSet<SandwichIngredientEF> SandwichIngredients { get; set; }
    }
}
