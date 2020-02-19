using System;
using System.Collections.Generic;
using System.IO;

namespace DataSetLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a choice to upload:");
            Console.WriteLine("1. Accidents");
            Console.WriteLine("2. Casualties");
            Console.WriteLine("3. Vehicles");
            Console.WriteLine();
            Console.Write("Choice Number: ");
            var option = Console.ReadLine();

            int.TryParse(option, out int selected);

            switch (selected)
            {
                case 1:
                    var accidentService = new AccidentService();
                    accidentService.ProcessAccident();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
    }
}
