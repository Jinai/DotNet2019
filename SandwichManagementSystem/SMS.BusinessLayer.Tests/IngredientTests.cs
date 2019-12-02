using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.BusinessLayer.Domain;
using SMS.Shared;
using SMS.Shared.Enums;

namespace SMS.BusinessLayer.Tests
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

            var ing1 = new Ingredient { Name = ts1 };
            var ing2 = new Ingredient { Name = ts2 };

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
            var ts1 = new TranslatedString("Peanut", "Cacahučte", "Pinda");
            var ts2 = new TranslatedString("Egg", "Oeuf", "Ei");

            var ing1 = new Ingredient { Name = ts1, IsAllergen = true };
            var ing2 = new Ingredient { Name = ts2, IsAllergen = true };

            Assert.AreEqual("Peanut*", ing1.ToString(EN));
            Assert.AreEqual("Cacahučte*", ing1.ToString(FR));
            Assert.AreEqual("Pinda*", ing1.ToString(NL));

            Assert.AreEqual("Egg*", ing2.ToString(EN));
            Assert.AreEqual("Oeuf*", ing2.ToString(FR));
            Assert.AreEqual("Ei*", ing2.ToString(NL));
        }
    }
}
