using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSetLoader
{
    public class VehicleService
    {
        public void ProcessVehicles(bool skipLines, int linesToSkip = 0)
        {
            Console.WriteLine();
            Console.Write("Please enter a file location to process from: ");
            var fileLocation = Console.ReadLine();

            var currentCount = 1;
            var lastSave = 1;
            var vehicleList = new List<Vehicle>();

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

                    var accident = GenerateVehicle(columns);

                    vehicleList.Add(accident);
                    if (currentCount == lastSave + 50000)
                    {
                        using (var dbContext = new DatabaseContext())
                        {
                            dbContext.AddRange(vehicleList);
                            dbContext.SaveChanges();
                            vehicleList.Clear();
                        }
                        lastSave += 50000;
                    }

                    currentCount++;
                    Console.Write(currentCount);
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                using (var dbContext = new DatabaseContext())
                {
                    dbContext.Vehicles.AddRange(vehicleList);
                    dbContext.SaveChanges();
                }

            }
        }

        private static Vehicle GenerateVehicle(string[] columns)
        {
            return new Vehicle
            {
                Accident_Index = columns[0],
                Vehicle_Reference = columns[1]?.ConvertToNullableInt(),
                Vehicle_Type = columns[2]?.ConvertToNullableInt(),
                Towing_and_Articulation = columns[3]?.ConvertToNullableInt(),
                Vehicle_Manoeuvre = columns[4]?.ConvertToNullableInt(),
                Vehicle_Location_Restricted_Lane = columns[5]?.ConvertToNullableInt(),
                Junction_Location = columns[6]?.ConvertToNullableInt(),
                Skidding_and_Overturning = columns[7]?.ConvertToNullableInt(),
                Hit_Object_off_Carriageway = columns[8]?.ConvertToNullableInt(),
                First_Point_of_Impact = columns[9]?.ConvertToNullableInt(),
                Was_Vehicle_Left_Hand_Driven = columns[10]?.ConvertToNullableInt(),
                Journey_Purpose_of_Driver = columns[11]?.ConvertToNullableInt(),
                Sex_of_Driver = columns[12]?.ConvertToNullableInt(),
                Age_of_Driver = columns[13]?.ConvertToNullableInt(),
                Age_Band_of_Driver = columns[14]?.ConvertToNullableInt(),
                Engine_Capacity_CC = columns[15]?.ConvertToNullableInt(),
                Propulsion_Code = columns[16]?.ConvertToNullableInt(),
                Age_of_Vehicle = columns[17]?.ConvertToNullableInt(),
                Driver_IMD_Decile = columns[18]?.ConvertToNullableInt(),
                Driver_Home_Area_Type = columns[19]?.ConvertToNullableInt()
            };
        }
    }
}
