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
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MealDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealCompositionEF>().HasKey(mc => new { mc.MealId, mc.IngredientId });

            modelBuilder.Entity<MealCompositionEF>()
                .HasOne<MealEF>(mc => mc.Meal)
                .WithMany(m => m.MealCompositions)
                .HasForeignKey(mc => mc.MealId);

            modelBuilder.Entity<MealCompositionEF>()
                .HasOne<IngredientEF>(mc => mc.Ingredient)
                .WithMany(i => i.MealCompositions)
                .HasForeignKey(mc => mc.IngredientId);
        }

        public DbSet<SupplierEF> Suppliers { get; set; }
        public DbSet<MealEF> Meals { get; set; }
        public DbSet<IngredientEF> Ingredients { get; set; }
        public DbSet<MealCompositionEF> MealCompositions { get; set; }
    }
}
