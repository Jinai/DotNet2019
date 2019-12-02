using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.BusinessLayer.Domain;
using SMS.Shared;
using SMS.Shared.Enums;
using SMS.Shared.Exceptions;

namespace SMS.BusinessLayer.Tests
{
    [TestClass]
    public class SandwichTests
    {
        [TestMethod]
        public void Test_ToString()
        {
            // Arrange
            var ts1 = new TranslatedString("Peanut butter and jelly sandwich", "Sandwich beurre de cacahuète et confiture", "Broodje pindakaas en jam");
            var ts2 = new TranslatedString("Ham and cheese sandwich", "Sandwich jambon et fromage", "Broodje ham en kaas");
            var ts3 = new TranslatedString("Peanut butter", "Beurre de cacahuète", "Pindakaas");
            var ts4 = new TranslatedString("Jelly", "Confiture", "Jam");
            var ts5 = new TranslatedString("Ham", "Jambon", "Ham");
            var ts6 = new TranslatedString("Cheese", "Fromage", "Kaas");

            var sand1 = new Sandwich { Name = ts1, Supplier = null };
            var sand2 = new Sandwich { Name = ts2, Supplier = null };
            var sand3 = new Sandwich { Name = new TranslatedString("A", "B", "C"), Supplier = null };

            var ing1 = new Ingredient { Name = ts3, IsAllergen = true };
            var ing2 = new Ingredient { Name = ts4 };
            var ing3 = new Ingredient { Name = ts5 };
            var ing4 = new Ingredient { Name = ts6 };

            // Act
            sand1.Ingredients.Add(ing1);
            sand1.Ingredients.Add(ing2);
            sand2.Ingredients.Add(ing3);
            sand2.Ingredients.Add(ing4);

            // Assert
            Assert.AreEqual("Peanut butter and jelly sandwich - Peanut butter*, Jelly", sand1.ToString(Language.English));
            Assert.AreEqual("Sandwich beurre de cacahuète et confiture - Beurre de cacahuète*, Confiture", sand1.ToString(Language.French));
            Assert.AreEqual("Broodje pindakaas en jam - Pindakaas*, Jam", sand1.ToString(Language.Dutch));

            Assert.AreEqual("Ham and cheese sandwich - Ham, Cheese", sand2.ToString(Language.English));
            Assert.AreEqual("Sandwich jambon et fromage - Jambon, Fromage", sand2.ToString(Language.French));
            Assert.AreEqual("Broodje ham en kaas - Ham, Kaas", sand2.ToString(Language.Dutch));

            Assert.AreEqual("A - ", sand3.ToString(Language.English));
            Assert.AreEqual("B - ", sand3.ToString(Language.French));
            Assert.AreEqual("C - ", sand3.ToString(Language.Dutch));
        }

        [TestMethod]
        public void Test_HasAllergen()
        {
            // Arrange
            var sand1 = new Sandwich();
            var sand2 = new Sandwich();

            var ing1 = new Ingredient { IsAllergen = true };
            var ing2 = new Ingredient { IsAllergen = false };

            // Act
            sand1.Ingredients.Add(ing1);
            sand2.Ingredients.Add(ing2);

            // Assert
            Assert.IsTrue(sand1.HasAllergen());
            Assert.IsFalse(sand2.HasAllergen());
        }

        [TestMethod]
        public void Test_CheckValidity_ThrowsException_WhenPropertiesAreNull()
        {
            var sand1 = new Sandwich();
            var sand2 = new Sandwich { Name = null, Supplier = new Supplier() };
            var sand3 = new Sandwich { Name = new TranslatedString("A", "B", "C"), Supplier = null };
            Assert.ThrowsException<InvalidSandwichException>(() => sand1.CheckValidity());
            Assert.ThrowsException<InvalidSandwichException>(() => sand2.CheckValidity());
            Assert.ThrowsException<InvalidSandwichException>(() => sand3.CheckValidity());
        }
    }
}
