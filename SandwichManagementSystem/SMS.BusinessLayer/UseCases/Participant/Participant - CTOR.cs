using SMS.BusinessLayer.Domain;
using SMS.DataLayer;
using System;

namespace SMS.BusinessLayer.UseCases.Participant
{
    public partial class Participant
    {
        public IRepository<Sandwich, int> SandwichRepo { get; }
        public IRepository<Ingredient, int> IngredientRepo { get; }

        public Participant(IRepository<Sandwich, int> sandwichRepo, IRepository<Ingredient, int> ingredientRepo)
        {
            SandwichRepo = sandwichRepo ?? throw new ArgumentNullException(nameof(sandwichRepo));
            IngredientRepo = ingredientRepo ?? throw new ArgumentNullException(nameof(ingredientRepo));
        }
    }
}
