using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSBusinessLogic;

namespace SMSBusinessLogicTests
{
    [TestClass]
    public class IngredientTests
    {
        public static Language EN = Language.English;
        public static Language FR = Language.French;
        public static Language NL = Language.Dutch;

        [TestMethod]
        public void TestToStringWithoutAllergen()
        {
            var ing1 = new Ingredient("Ham", "Jambon", "Ham");
            var ing2 = new Ingredient("Cheese", "Fromage", "Kaas");

            Assert.AreEqual("Ham", ing1.ToString(EN));
            Assert.AreEqual("Jambon", ing1.ToString(FR));
            Assert.AreEqual("Ham", ing1.ToString(NL));

            Assert.AreEqual("Cheese", ing2.ToString(EN));
            Assert.AreEqual("Fromage", ing2.ToString(FR));
            Assert.AreEqual("Kaas", ing2.ToString(NL));
        }

        [TestMethod]
        public void TestToStringWithAllergen()
        {
            var ing1 = new Ingredient("Peanut", "Cacahuète", "Pinda", true);
            var ing2 = new Ingredient("Egg", "Oeuf", "Ei", true);

            Assert.AreEqual("Peanut*", ing1.ToString(EN));
            Assert.AreEqual("Cacahuète*", ing1.ToString(FR));
            Assert.AreEqual("Pinda*", ing1.ToString(NL));

            Assert.AreEqual("Egg*", ing2.ToString(EN));
            Assert.AreEqual("Oeuf*", ing2.ToString(FR));
            Assert.AreEqual("Ei*", ing2.ToString(NL));
        }
    }
}
