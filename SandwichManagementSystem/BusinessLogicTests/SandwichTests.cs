using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SMSBusinessLogic;

namespace SMSBusinessLogicTests
{
    [TestClass]
    public class SandwichTests
    {
        public static Language EN = Language.English;
        public static Language FR = Language.French;
        public static Language NL = Language.Dutch;

        [TestMethod]
        public void TestToString()
        {
            // Arrange
            var sand1 = new Sandwich("Peanut butter and jelly sandwich", "Sandwich beurre de cacahuète et confiture", "Broodje pindakaas en jam", null);
            var sand2 = new Sandwich("Ham and cheese sandwich", "Sandwich jambon et fromage", "Broodje ham en kaas", null);

            var ing1 = new Ingredient("Peanut butter", "Beurre de cacahuète", "Pindakaas", true);
            var ing2 = new Ingredient("Jelly", "Confiture", "Jam");
            var ing3 = new Ingredient("Ham", "Jambon", "Ham");
            var ing4 = new Ingredient("Cheese", "Fromage", "Kaas");

            // Act
            sand1.Ingredients.Add(ing1);
            sand1.Ingredients.Add(ing2);
            sand2.Ingredients.Add(ing3);
            sand2.Ingredients.Add(ing4);

            // Assert
            Assert.IsTrue(sand1.HasAllergen());
            Assert.AreEqual("Peanut butter and jelly sandwich - Peanut butter*, Jelly", sand1.ToString(EN));
            Assert.AreEqual("Sandwich beurre de cacahuète et confiture - Beurre de cacahuète*, Confiture", sand1.ToString(FR));
            Assert.AreEqual("Broodje pindakaas en jam - Pindakaas*, Jam", sand1.ToString(NL));

            Assert.IsFalse(sand2.HasAllergen());
            Assert.AreEqual("Ham and cheese sandwich - Ham, Cheese", sand2.ToString(EN));
            Assert.AreEqual("Sandwich jambon et fromage - Jambon, Fromage", sand2.ToString(FR));
            Assert.AreEqual("Broodje ham en kaas - Ham, Kaas", sand2.ToString(NL));
        }

        [TestMethod]
        public void TestHasAllergen()
        {
            // Arrange
            var sand1 = new Sandwich();
            var sand2 = new Sandwich();

            var ing1 = new Ingredient() { Allergen = true };
            var ing2 = new Ingredient() { Allergen = false };

            // Act
            sand1.Ingredients.Add(ing1);
            sand2.Ingredients.Add(ing2);

            // Assert
            Assert.IsTrue(sand1.HasAllergen());
            Assert.IsFalse(sand2.HasAllergen());
        }
    }
}
