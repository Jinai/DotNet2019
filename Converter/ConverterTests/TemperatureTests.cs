using Converter.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConverterTests
{
    [TestClass]
    public class TemperatureTests
    {
        [DataTestMethod]
        [DataRow(45, 113)]
        [DataRow(35, 95)]
        [DataRow(48, 118)]
        [DataRow(65, 149)]
        public void TestCelsiusToFahrenheit(int valeur, int result)
        {
            var sut = Temperature.CelsiusToFahrenheit(valeur);
            Assert.AreEqual(sut, result);
        }

        [DataTestMethod]
        [DataRow(113, 45)]
        [DataRow(95, 35)]
        [DataRow(118, 48)]
        [DataRow(149, 65)]
        public void TestFahrenheitToCelsius(int valeur, int result)
        {
            var sut = Temperature.FahrenheitToCelsius(valeur);
            Assert.AreEqual(sut, result);
        }

        [DataTestMethod]
        [DataRow(45, 318)]
        [DataRow(35, 308)]
        [DataRow(48, 321)]
        [DataRow(65, 338)]
        public void TestCelsiusToKelvin(int valeur, int result)
        {
            var sut = Temperature.CelsiusToKelvin(valeur);
            Assert.AreEqual(sut, result);
        }

        [DataTestMethod]
        [DataRow(318, 45)]
        [DataRow(308, 35)]
        [DataRow(321, 48)]
        [DataRow(338, 65)]
        public void TestKelvinToCelsius(int valeur, int result)
        {
            var sut = Temperature.KelvinToCelsius(valeur);
            Assert.AreEqual(sut, result);
        }

        [DataTestMethod]
        [DataRow(30, 272)]
        [DataRow(100, 311)]
        [DataRow(-50, 228)]
        [DataRow(-400, 33)]
        public void TestFahrenheitToKelvin(int valeur, int result)
        {
            var sut = Temperature.FahrenheitToKelvin(valeur);
            Assert.AreEqual(sut, result);
        }

        [DataTestMethod]
        [DataRow(272, 30)]
        [DataRow(311, 100)]
        [DataRow(228, -49)]
        [DataRow(33, -400)]
        public void TestKelvinToFahrenheit(int valeur, int result)
        {
            var sut = Temperature.KelvinToFahrenheit(valeur);
            Assert.AreEqual(sut, result);
        }
    }
}
