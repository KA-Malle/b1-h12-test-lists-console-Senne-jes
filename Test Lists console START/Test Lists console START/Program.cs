using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Test_Lists_console_START
{
    internal class Program
    {
        /*
         * NAAM: Senne Jespers
         * KLAS: 6ADB
         * DATUM: 20/11/2025
        */

        static void Main(string[] args)
        {
            // consolekleuren instellen
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            // Declaratie
            List<string[]> cars = new List<string[]>();
            // Merk type brandstof prijs omschrijving uitstoot

            // Bestand inlezen
            BestandInlezen();

            ToonWagens(cars);

            // Zoekopdrachten
            Console.WriteLine("\n--- Zoekopdrachten en filters ---\n");

            #region Brandstof

            // 1. (Lambda) Zoek de eerste wagen met benzine als brandstof
            Console.WriteLine("Eerste wagen met benzine:");

            bool exists = cars.Exists(element => element == "Fait");
            if (exists)
                Console.WriteLine(cars);
            else
                Console.WriteLine("Niet gevonden");

            #endregion

            #region prijs
            // 2. (Lambda) Vind alle wagens onder een bepaalde prijs (bijvoorbeeld onder 15000 euro)
            Console.WriteLine("\nWagens onder 15.000 EUR:");

            if (cars[15].Exists(el => el < 15))
            {
                Console.WriteLine(cars);
            }
            else
            {
                Console.WriteLine("niet gevonden");
            }

            #endregion

            #region merk
            // 3. (Lambda) Zoek wagens van een specifiek merk (bijvoorbeeld "Fiat")
            Console.WriteLine("\nAlle wagens van het merk Fiat:");
            // Zoeken naar wagen van het merk 
            List<string> Merk = new List<string>();
            string heeftGetBoven50 = Merk.Exists(elem => elem = ("Fiat"));
            Console.Write(cars); // True
            #endregion

            #region C02
            // 4. (Predicate) Zoek wagens met CO2-uitstoot hoger dan 120 g/km
            Console.WriteLine("\nWagens met CO2-uitstoot hoger dan 120 g/km:");
            // aanvullen...

             List<int> hogerDan120 = cars.FindAll(UitstootHogerDan120);

            #endregion

            #region Toevoegen 

            // Voeg een wagen toe + tonen
            // aanvullen...
            Console.WriteLine("Wil je een nieuwe wagen toevoegen?");
            string antwoord = Console.ReadLine();
            if (antwoord == "ja")
            {
                VoegEenWagenToe(cars);

            }
            else
            {

            }

            #endregion

            // wachten op enter
            Console.WriteLine("\nDruk op enter om te eindigen.");
            Console.ReadLine();

         List<string[]> newCar = cars.FindAll();

            ToonWagens(cars);

        }

        private static void VoegEenWagenToe(List<string[]> cars)
        {
            Console.WriteLine("Voeg een nieuwe wagen toe (voor de details in, gescheiden met door puntkomma's");

        }

        // Kijkt of de prijs onder 15 euro ligt
        

        private static bool UitstootHogerDan120(string[] cars)
        {
            return cars[15] >= 120;
        }

        private static void ToonWagens(List<string[]> cars)
        {
            foreach (string[] car in cars)
            {
                Console.WriteLine("{0}: {1} <{2}>", car[35].Replace('.', ','), car[25], car[15], car[15]);
                Console.WriteLine(cars);
            }
        }

        
        // Bestand inlezen
        private static List<string[]> BestandInlezen()
        {
            List<string[]> tempCars = new List<string[]>();
            string volledigeLijn;

            using (StreamReader streamLees = new StreamReader("auto_export_file.txt"))
            {
                while (!streamLees.EndOfStream)
                {
                    volledigeLijn = streamLees.ReadLine();
                    tempCars.Add(volledigeLijn.Split(';'));
                }
            }
       //     Console.WriteLine("Er zijn {0} auto's verwerkt.", tempCars.Count);

            return tempCars;

        }


        // De eerste parameter is de tekst die verkort moet worden
        // De tweede parameter is de maximale tekstlengte
        // De methode geeft de verkorte tekst terug
        private static string ShortItem(string item, int lengte)
        {
            return item.Length > lengte ? item.Substring(0, lengte) + "..." : item;
        }
    }
}
