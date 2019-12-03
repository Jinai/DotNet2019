using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.BusinessLayer.Domain;
using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Exceptions;

namespace SMS.BusinessLayer.Tests
{
    [TestClass]
    public class MealTests
    {
        [TestMethod]
        public void Test_ToString()
        {
            // Arrange
            var ts1 = new TranslatedString("Peanut butter and jelly", "Beurre de cacahuète et confiture", "Pindakaas en jam");
            var ts2 = new TranslatedString("Ham and cheese", "Jambon et fromage", "Ham en kaas");
            var ts3 = new TranslatedString("Peanut butter", "Beurre de cacahuète", "Pindakaas");
            var ts4 = new TranslatedString("Jelly", "Confiture", "Jam");
            var ts5 = new TranslatedString("Ham", "Jambon", "Ham");
            var ts6 = new TranslatedString("Cheese", "Fromage", "Kaas");

            var meal1 = new Meal { MealType = MealType.Sandwich, Name = ts1, Supplier = null };
            var meal2 = new Meal { MealType = MealType.Sandwich, Name = ts2, Supplier = null };
            var meal3 = new Meal { MealType = MealType.Sandwich, Name = new TranslatedString("A", "B", "C"), Supplier = null };

            var ing1 = new Ingredient { Name = ts3, IsAllergen = true };
            var ing2 = new Ingredient { Name = ts4 };
            var ing3 = new Ingredient { Name = ts5 };
            var ing4 = new Ingredient { Name = ts6 };

            // Act
            meal1.Ingredients.Add(ing1);
            meal1.Ingredients.Add(ing2);
            meal2.Ingredients.Add(ing3);
            meal2.Ingredients.Add(ing4);

            // Assert
            Assert.AreEqual("[Sandwich] Peanut butter and jelly - Peanut butter*, Jelly", meal1.ToString(Language.English));
            Assert.AreEqual("[Sandwich] Beurre de cacahuète et confiture - Beurre de cacahuète*, Confiture", meal1.ToString(Language.French));
            Assert.AreEqual("[Sandwich] Pindakaas en jam - Pindakaas*, Jam", meal1.ToString(Language.Dutch));

            Assert.AreEqual("[Sandwich] Ham and cheese - Ham, Cheese", meal2.ToString(Language.English));
            Assert.AreEqual("[Sandwich] Jambon et fromage - Jambon, Fromage", meal2.ToString(Language.French));
            Assert.AreEqual("[Sandwich] Ham en kaas - Ham, Kaas", meal2.ToString(Language.Dutch));

            Assert.AreEqual("[Sandwich] A - ", meal3.ToString(Language.English));
            Assert.AreEqual("[Sandwich] B - ", meal3.ToString(Language.French));
            Assert.AreEqual("[Sandwich] C - ", meal3.ToString(Language.Dutch));
        }

        [TestMethod]
        public void Test_HasAllergen()
        {
            // Arrange
            var meal1 = new Meal();
            var meal2 = new Meal();

            var ing1 = new Ingredient { IsAllergen = true };
            var ing2 = new Ingredient { IsAllergen = false };

            // Act
            meal1.Ingredients.Add(ing1);
            meal2.Ingredients.Add(ing2);

            // Assert
            Assert.IsTrue(meal1.HasAllergen());
            Assert.IsFalse(meal2.HasAllergen());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenPropertiesAreNull()
        {
            var meal1 = new Meal();
            var meal2 = new Meal { Name = null, Supplier = new Supplier() };
            var meal3 = new Meal { Name = new TranslatedString("A", "B", "C"), Supplier = null };
            Assert.ThrowsException<InvalidMealException>(() => meal1.CheckValidity());
            Assert.ThrowsException<InvalidMealException>(() => meal2.CheckValidity());
            Assert.ThrowsException<InvalidMealException>(() => meal3.CheckValidity());
        }
    }
}
