using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSetLoader
{
    public class CasualtiesService
    {
        public void ProcessCasualties(bool skipLines, int linesToSkip = 0)
        {
            Console.WriteLine();
            Console.Write("Please enter a file location to process from: ");
            var fileLocation = Console.ReadLine();

            var currentCount = 1;
            var lastSave = 1;
            var casualtiesList = new List<Casualty>();

            using (var streamReader = new StreamReader(fileLocation))
            {
                string currentLine;

                if (skipLines)
                {
                    for (var i = 0; i < linesToSkip + 1; i++)
                    {
                        streamReader.ReadLine();
                    }
                }

                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    var columns = currentLine.Split(',');
                    if (columns[0] == "Accident_Index")
                    {
                        continue;
                    }

                    var accident = GenerateCasualty(columns);

                    casualtiesList.Add(accident);
                    if (currentCount == lastSave + 50000)
                    {
                        using (var dbContext = new DatabaseContext())
                        {
                            dbContext.AddRange(casualtiesList);
                            dbContext.SaveChanges();
                            casualtiesList.Clear();
                        }
                        lastSave += 50000;
                    }

                    currentCount++;
                    Console.Write(currentCount);
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                using (var dbContext = new DatabaseContext())
                {
                    dbContext.Casualties.AddRange(casualtiesList);
                    dbContext.SaveChanges();
                }

            }
        }

        private static Casualty GenerateCasualty(string[] columns)
        {
            return new Casualty
            {
                Accident_Index = columns[0],
                Vehicle_Reference = columns[1]?.ConvertToNullableInt(),
                Casualty_Reference = columns[2]?.ConvertToNullableInt(),
                Casualty_Class = columns[3]?.ConvertToNullableInt(),
                Sex_of_Casualty = columns[4]?.ConvertToNullableInt(),
                Age_of_Casualty = columns[5]?.ConvertToNullableInt(),
                Age_Band_of_Casualty = columns[6]?.ConvertToNullableInt(),
                Casualty_Severity = columns[7]?.ConvertToNullableInt(),
                Pedestrian_Location = columns[8]?.ConvertToNullableInt(),
                Pedestrian_Movement = columns[9]?.ConvertToNullableInt(),
                Car_Passenger = columns[10]?.ConvertToNullableInt(),
                Bus_or_Coach_Passenger = columns[11]?.ConvertToNullableInt(),
                Pedestrian_Road_Maintenance_Worker = columns[12]?.ConvertToNullableInt(),
                Casualty_Type = columns[13]?.ConvertToNullableInt(),
                Casualty_Home_Area_Type = columns[14]?.ConvertToNullableInt()
            };
        }
    }
}
