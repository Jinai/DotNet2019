using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMS.Shared.Enums;
using System;

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
            var ts1 = new TranslatedString("Peanut butter and jelly", "Beurre de cacahuète et confiture", "Pindakaas en jam");
            var ts2 = new TranslatedString("Ham and cheese", "Jambon et fromage", "Ham en kaas");
            var ts3 = new TranslatedString("some english name", "some french name", "some dutch name");

            // Assert
            Assert.AreEqual("Peanut butter and jelly", ts1.ToString(EN));
            Assert.AreEqual("Beurre de cacahuète et confiture", ts1.ToString(FR));
            Assert.AreEqual("Pindakaas en jam", ts1.ToString(NL));

            Assert.AreEqual("Ham and cheese", ts2.ToString(EN));
            Assert.AreEqual("Jambon et fromage", ts2.ToString(FR));
            Assert.AreEqual("Ham en kaas", ts2.ToString(NL));

            Assert.AreEqual("some english name", ts3.ToString(EN));
            Assert.AreEqual("some french name", ts3.ToString(FR));
            Assert.AreEqual("some dutch name", ts3.ToString(NL));
        }

        [TestMethod]
        public void Test_IncompleteTranslationThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => new TranslatedString(null, null, null));
            Assert.ThrowsException<ArgumentException>(() => new TranslatedString("", null, null));
            Assert.ThrowsException<ArgumentException>(() => new TranslatedString(null, "", null));
            Assert.ThrowsException<ArgumentException>(() => new TranslatedString(null, null, ""));
            Assert.ThrowsException<ArgumentException>(() => new TranslatedString("", "", ""));
            Assert.ThrowsException<ArgumentException>(() => new TranslatedString("\t", "   ", "\n"));
        }
    }
}
