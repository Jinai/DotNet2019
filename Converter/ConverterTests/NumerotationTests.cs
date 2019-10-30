using Converter.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumerotationTests
{
    [TestClass]
    public class NumerotationTests
    {
        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(8, "VIII")]
        [DataRow(17, "XVII")]
        [DataRow(46, "XLVI")]
        [DataRow(1030, "MXXX")]
        [DataRow(970, "CMLXX")]
        [DataRow(509, "DIX")]
        [DataRow(1666, "MDCLXVI")]
        public void TestArabicToRoman(int valeur, string result)
        {
            var sut = Numerotation.ArabicToRoman(valeur);
            Assert.AreEqual(result, sut);
        }

        [DataTestMethod]
        [DataRow("I", 1)]
        [DataRow("VIII", 8)]
        [DataRow("XVII", 17)]
        [DataRow("XLVI", 46)]
        [DataRow("MXXX", 1030)]
        [DataRow("CMLXX", 970)]
        [DataRow("DIX", 509)]
        [DataRow("MDCLXVI", 1666)]
        public void TestRomanToArabic(string valeur, int result)
        {
            var sut = Numerotation.RomanToArabic(valeur);
            Assert.AreEqual(result, sut);
        }
    }
}
