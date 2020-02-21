using System;
using System.Collections.Generic;
using System.IO;

namespace DataSetLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            bool skip;
            int linesToSkip;
            bool continueUploads = true;

            while (continueUploads)
            {
                Console.WriteLine("Please enter a choice to upload:");
                Console.WriteLine("1. Accidents");
                Console.WriteLine("2. Vehicles");
                Console.WriteLine("3. Casualties");
                Console.WriteLine();
                Console.Write("Choice Number: ");
                var option = Console.ReadLine();
                int.TryParse(option, out int selected);

                switch (selected)
                {
                    case 1:
                        var accidentService = new AccidentService();
                        Console.Write("Would you like to skip lines? (Y/N): ");
                        skip = Console.ReadLine() == "Y" ? true : false;
                        if (skip)
                        {
                            Console.WriteLine();
                            Console.Write("How many lines would you like to skip? : ");
                            linesToSkip = int.Parse(Console.ReadLine());
                            accidentService.ProcessAccidents(skip, linesToSkip);
                            break;
                        }
                        accidentService.ProcessAccidents(false);
                        break;
                    case 2:
                        var vehicleService = new VehicleService();
                        Console.Write("Would you like to skip lines? (Y/N): ");
                        skip = Console.ReadLine() == "Y" ? true : false;
                        if (skip)
                        {
                            Console.WriteLine();
                            Console.Write("How many lines would you like to skip? : ");
                            linesToSkip = int.Parse(Console.ReadLine());
                            vehicleService.ProcessVehicles(skip, linesToSkip);
                            break;
                        }
                        vehicleService.ProcessVehicles(false);
                        break;
                    case 3:
                        var casualtyService = new CasualtiesService();
                        Console.Write("Would you like to skip lines? (Y/N): ");
                        skip = Console.ReadLine() == "Y" ? true : false;
                        if (skip)
                        {
                            Console.WriteLine();
                            Console.Write("How many lines would you like to skip? : ");
                            linesToSkip = int.Parse(Console.ReadLine());
                            casualtyService.ProcessCasualties(skip, linesToSkip);
                            break;
                        }
                        casualtyService.ProcessCasualties(false);
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }

                Console.SetCursorPosition(0, Console.CursorTop + 1);
                Console.WriteLine();
                Console.Write("Would you like to upload another file? (Y/N) : ");
                continueUploads = Console.ReadLine() == "Y" ? true : false;
                Console.WriteLine();
            }
        }
    }
}
