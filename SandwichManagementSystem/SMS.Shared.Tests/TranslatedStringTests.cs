using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Shared.Enums;

namespace SMS.Shared.Tests
{
    [TestClass]
    public class TranslatedStringTests
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
            var ts3 = new TranslatedString("some english name", "some french name", "some dutch name");

            // Assert
            Assert.AreEqual("Peanut butter and jelly sandwich", ts1.ToString(EN));
            Assert.AreEqual("Sandwich beurre de cacahuète et confiture", ts1.ToString(FR));
            Assert.AreEqual("Broodje pindakaas en jam", ts1.ToString(NL));

            Assert.AreEqual("Ham and cheese sandwich", ts2.ToString(EN));
            Assert.AreEqual("Sandwich jambon et fromage", ts2.ToString(FR));
            Assert.AreEqual("Broodje ham en kaas", ts2.ToString(NL));

            Assert.AreEqual("some english name", ts3.ToString(EN));
            Assert.AreEqual("some french name", ts3.ToString(FR));
            Assert.AreEqual("some dutch name", ts3.ToString(NL));
        }
    }
}
