using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Converter.Tools
{
    public class Numerotation
    {
        public static string ArabicToRoman(int numberToConvert)
        {
            if (numberToConvert < 1 || numberToConvert > 3999)
            {
                throw new ArgumentOutOfRangeException("Please use numbers between 1 and 3999");
            }

            // On déclare une liste de tuples, et pour chaque tuple on définit un alias
            // pour la 1e et la 2e valeur (Symbol et Value)
            var romanSymbols = new (string Symbol, int Value)[]
            {
                ("M", 1000),
                ("CM", 900),
                ("D", 500),
                ("CD", 400),
                ("C", 100),
                ("XC", 90),
                ("L", 50),
                ("XL", 40),
                ("X", 10),
                ("IX", 9),
                ("V", 5),
                ("IV", 4),
                ("I", 1)
            };

            StringBuilder result = new StringBuilder();
            foreach(var (Symbol, Value) in romanSymbols)
            {
                // On parcourt les tuples en utilisant les alias
                while (numberToConvert >= Value)
                {
                    result.Append(Symbol);
                    numberToConvert -= Value;
                }
            }
            return result.ToString();
        }

        public static int RomanToArabic(string number)
        {
            Dictionary<char, int> romanSymbols = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            int result = 0;
            int lastValue = 0;
            string numberToConvert = number.ToUpper(); // On ne travaille qu'avec des majuscules

            for (int i = numberToConvert.Length - 1; i >= 0; i--)
            {
                // On parcourt le nombre chiffre par chiffre en commençant par la fin
                int currentValue = romanSymbols[numberToConvert[i]];
                if (currentValue >= lastValue)
                {
                    // Si le chiffre actuel est >= que le précédent, on additionne au total (exemple: [V]I)
                    result += currentValue;
                }
                else
                {
                    // Sinon c'est qu'il faut soustraire (exemple: [I]X)
                    result -= currentValue;
                }
                lastValue = currentValue;
            }
            return result;
        }
    }
}
