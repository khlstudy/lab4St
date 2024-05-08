using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4St
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введіть назву країни: ");
            string countryName = Console.ReadLine();

            Console.Write("Введіть материк, на якому знаходиться країна: ");
            string continent = Console.ReadLine();

            Console.Write("Введіть столицю країни: ");
            string capitalCity = Console.ReadLine();

            double population = GetValidNumber("кількість населення");
            double area = GetValidNumber("площу, кв. км");
            double lifeExpectancy = GetValidNumber("середній вік життя");

            Console.Write("Чи є країна членом Європейського Союзу? (y - так, n - ні): ");
            ConsoleKeyInfo keyIsInEU = Console.ReadKey();
            Console.WriteLine();

            Console.Write("Чи є країна членом НАТО? (y - так, n - ні): ");
            ConsoleKeyInfo keyIsInNATO = Console.ReadKey();
            Console.WriteLine();

            Country ourCountry = new Country();

            ourCountry.CountryName = countryName;
            ourCountry.Continent = continent;
            ourCountry.CapitalCity = capitalCity;
            ourCountry.Population = population;
            ourCountry.Area = area;
            ourCountry.LifeExpectancy = lifeExpectancy;
            ourCountry.IsInEU = keyIsInEU.Key == ConsoleKey.Y;
            ourCountry.IsInNATO = keyIsInNATO.Key == ConsoleKey.Y;

            double populationDensity = ourCountry.CalculatePopulationDensity();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ІНФОРМАЦІЯ ПРО КРАЇНУ");
            Console.ResetColor(); 
            Console.WriteLine("Назва країни: " + ourCountry.CountryName);
            Console.WriteLine("Материк: " + ourCountry.Continent);
            Console.WriteLine("Столиця країни: " + ourCountry.CapitalCity);
            Console.WriteLine("Кількість населення: " + ourCountry.Population);
            Console.WriteLine("Площа: " + ourCountry.Area.ToString("0.000"));
            Console.ForegroundColor = ourCountry.IsInEU ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(ourCountry.IsInEU ? "Країна є членом ЄС" : "Країна не є членом ЄС");
            Console.ResetColor();
            Console.ForegroundColor = ourCountry.IsInNATO ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(ourCountry.IsInNATO ? "Країна є членом НАТО" : "Країна не є членом НАТО");
            Console.ResetColor();
            Console.WriteLine("Густина населення: " + populationDensity.ToString("0.00"));
            if (ourCountry.IsPopulationDensityAboveAverage())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Густина населення країни більше середньої густини населення Землі");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Густина населення країни менше або рівна середній густині населення Землі");
            }
            Console.ReadLine();


        }
        static double GetValidNumber(string prompt)
        {
            double number = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.Write($"Введіть {prompt}: ");
                string userInput = Console.ReadLine();
                validInput = double.TryParse(userInput, out number);
                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Помилка: Некоректне значення для {prompt}. Будь ласка, введіть число.");
                    Console.ResetColor();
                }
            }
            return number;
        }

    }
}
