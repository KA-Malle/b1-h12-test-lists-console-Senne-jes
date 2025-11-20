using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Lists_console_START
{
    internal class Program
    {
        /*
         * NAAM: 
         * KLAS:
         * DATUM:
        */

        static void Main(string[] args)
        {
            // consolekleuren instellen
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            // Declaratie
            List<string[]> cars = new List<string[]>();
            // aanvullen...


            // Bestand inlezen
            // aanvullen...


            // Zoekopdrachten
            Console.WriteLine("\n--- Zoekopdrachten en filters ---\n");

            // 1. (Lambda) Zoek de eerste wagen met benzine als brandstof
            Console.WriteLine("Eerste wagen met benzine:");
            // aanvullen...


            // 2. (Lambda) Vind alle wagens onder een bepaalde prijs (bijvoorbeeld onder 15000 euro)
            Console.WriteLine("\nWagens onder 15.000 EUR:");
            // aanvullen...


            // 3. (Lambda) Zoek wagens van een specifiek merk (bijvoorbeeld "Fiat")
            Console.WriteLine("\nAlle wagens van het merk Fiat:");
            // aanvullen...



            // 4. (Predicate) Zoek wagens met CO2-uitstoot hoger dan 120 g/km
            Console.WriteLine("\nWagens met CO2-uitstoot hoger dan 120 g/km:");
            // aanvullen...


            // Voeg een wagen toe + tonen
            // aanvullen...


            // wachten op enter
            Console.WriteLine("\nDruk op enter om te eindigen.");
            Console.ReadLine();
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
