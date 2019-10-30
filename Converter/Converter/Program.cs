using Converter.Tools;
using System;

namespace Converter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this conversion tool !");
            while (true)
            {
                Console.WriteLine();
                PrintMenu();
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 0)
                    break;
                else if (choice > 8)
                    continue;

                int result;
                string value;
                Console.Write("Enter value to convert: ");
                value = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        result = Temperature.CelsiusToFahrenheit(Convert.ToInt32(value));
                        Console.WriteLine($"{value}°C = {result}°F");
                        break;
                    case 2:
                        result = Temperature.CelsiusToKelvin(Convert.ToInt32(value));
                        Console.WriteLine($"{value}°C = {result} K");
                        break;
                    case 3:
                        result = Temperature.FahrenheitToCelsius(Convert.ToInt32(value));
                        Console.WriteLine($"{value}°F = {result}°C");
                        break;
                    case 4:
                        result = Temperature.FahrenheitToKelvin(Convert.ToInt32(value));
                        Console.WriteLine($"{value}°F = {result} K");
                        break;
                    case 5:
                        result = Temperature.KelvinToCelsius(Convert.ToInt32(value));
                        Console.WriteLine($"{value} K = {result}°C");
                        break;
                    case 6:
                        result = Temperature.KelvinToFahrenheit(Convert.ToInt32(value));
                        Console.WriteLine($"{value} K = {result}°F");
                        break;
                    case 7:
                        var roman = Numerotation.ArabicToRoman(Convert.ToInt32(value));
                        Console.WriteLine($"{value} = {roman}");
                        break;
                    case 8:
                        var arabic = Numerotation.RomanToArabic(value);
                        Console.WriteLine($"{value} = {arabic}");
                        break;
                }
                Console.WriteLine("__________________________");
            }
        }

        public static void PrintMenu()
        {
            string menu = @"1. Celsius to Fahrenheit
2. Celsius to Kelvin
3. Fahrenheit to Celsius
4. Fahrenheit to Kelvin
5. Kelvin to Celsius
6. Kelvin to Fahrenheit

7. Arabic to Roman
8. Roman to Arabic

0. Exit

Enter your choice: ";
            Console.Write(menu);
        }
    }
}
