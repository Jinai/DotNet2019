using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Tools
{
    public class Temperature
    {
        public static int CelsiusToFahrenheit(int Celsius)
        {
            return Convert.ToInt32(Celsius * 9.0 / 5 + 32);
        }

        public static int FahrenheitToCelsius(int Fahrenheit)
        {
            return Convert.ToInt32((Fahrenheit - 32) * 5.0 / 9);
        }

        public static int CelsiusToKelvin(int Celsius)
        {
            return Convert.ToInt32(Celsius + 273.15);
        }

        public static int KelvinToCelsius(int Kelvin)
        {
            return Convert.ToInt32(Kelvin - 273.15);
        }

        public static int FahrenheitToKelvin(int Fahrenheit)
        {
            return Convert.ToInt32((Fahrenheit + 459.67) * 5.0 / 9);
        }

        public static int KelvinToFahrenheit(int Kelvin)
        {
            return Convert.ToInt32(Kelvin * 9.0/5 - 459.67);
        }
    }
}
