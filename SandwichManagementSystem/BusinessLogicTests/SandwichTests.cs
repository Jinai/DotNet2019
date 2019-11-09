using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void Test_ToString()
        {
            // Arrange
            var ts1 = new TranslatedString("Peanut butter and jelly sandwich", "Sandwich beurre de cacahuète et confiture", "Broodje pindakaas en jam");
            var ts2 = new TranslatedString("Ham and cheese sandwich", "Sandwich jambon et fromage", "Broodje ham en kaas");
            var ts3 = new TranslatedString("Peanut butter", "Beurre de cacahuète", "Pindakaas");
            var ts4 = new TranslatedString("Jelly", "Confiture", "Jam");
            var ts5 = new TranslatedString("Ham", "Jambon", "Ham");
            var ts6 = new TranslatedString("Cheese", "Fromage", "Kaas");

            var sand1 = new Sandwich(ts1, null);
            var sand2 = new Sandwich(ts2, null);
            var sand3 = new Sandwich(new TranslatedString("A", "B", "C"), null);

            var ing1 = new Ingredient(ts3, true);
            var ing2 = new Ingredient(ts4);
            var ing3 = new Ingredient(ts5);
            var ing4 = new Ingredient(ts6);

            // Act
            sand1.Ingredients.Add(ing1);
            sand1.Ingredients.Add(ing2);
            sand2.Ingredients.Add(ing3);
            sand2.Ingredients.Add(ing4);

            // Assert
            Assert.AreEqual("Peanut butter and jelly sandwich - Peanut butter*, Jelly", sand1.ToString(EN));
            Assert.AreEqual("Sandwich beurre de cacahuète et confiture - Beurre de cacahuète*, Confiture", sand1.ToString(FR));
            Assert.AreEqual("Broodje pindakaas en jam - Pindakaas*, Jam", sand1.ToString(NL));

            Assert.AreEqual("Ham and cheese sandwich - Ham, Cheese", sand2.ToString(EN));
            Assert.AreEqual("Sandwich jambon et fromage - Jambon, Fromage", sand2.ToString(FR));
            Assert.AreEqual("Broodje ham en kaas - Ham, Kaas", sand2.ToString(NL));

            Assert.AreEqual("A - ", sand3.ToString(EN));
            Assert.AreEqual("B - ", sand3.ToString(FR));
            Assert.AreEqual("C - ", sand3.ToString(NL));
        }

        [TestMethod]
        public void Test_HasAllergen()
        {
            // Arrange
            var sand1 = new Sandwich();
            var sand2 = new Sandwich();

            var ing1 = new Ingredient() { IsAllergen = true };
            var ing2 = new Ingredient() { IsAllergen = false };

            // Act
            sand1.Ingredients.Add(ing1);
            sand2.Ingredients.Add(ing2);

            // Assert
            Assert.IsTrue(sand1.HasAllergen());
            Assert.IsFalse(sand2.HasAllergen());
        }
    }
}
