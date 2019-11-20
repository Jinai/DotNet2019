using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.BusinessLogic.Domain;
using SMS.Shared;

namespace SMS.BusinessLogic.Tests
{
    [TestClass]
    public class IngredientTests
    {
        public static Language EN = Language.English;
        public static Language FR = Language.French;
        public static Language NL = Language.Dutch;

        [TestMethod]
        public void Test_ToString_WithoutAllergen()
        {
            var ts1 = new TranslatedString("Ham", "Jambon", "Ham");
            var ts2 = new TranslatedString("Cheese", "Fromage", "Kaas");

            var ing1 = new Ingredient(ts1);
            var ing2 = new Ingredient(ts2);

            Assert.AreEqual("Ham", ing1.ToString(EN));
            Assert.AreEqual("Jambon", ing1.ToString(FR));
            Assert.AreEqual("Ham", ing1.ToString(NL));

            Assert.AreEqual("Cheese", ing2.ToString(EN));
            Assert.AreEqual("Fromage", ing2.ToString(FR));
            Assert.AreEqual("Kaas", ing2.ToString(NL));
        }

        [TestMethod]
        public void Test_ToString_WithAllergen()
        {
            var ts1 = new TranslatedString("Peanut", "Cacahuète", "Pinda");
            var ts2 = new TranslatedString("Egg", "Oeuf", "Ei");

            var ing1 = new Ingredient(ts1, true);
            var ing2 = new Ingredient(ts2, true);

            Assert.AreEqual("Peanut*", ing1.ToString(EN));
            Assert.AreEqual("Cacahuète*", ing1.ToString(FR));
            Assert.AreEqual("Pinda*", ing1.ToString(NL));

            Assert.AreEqual("Egg*", ing2.ToString(EN));
            Assert.AreEqual("Oeuf*", ing2.ToString(FR));
            Assert.AreEqual("Ei*", ing2.ToString(NL));
        }
    }
}
