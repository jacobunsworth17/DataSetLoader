using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSetLoader
{
    public class AccidentService
    {
        public void ProcessAccident()
        {
            Console.WriteLine();
            Console.Write("Please enter a file location to process from: ");
            var fileLocation = Console.ReadLine();

            var currentCount = 1;
            var lastSave = 1;
            var accidentList = new List<Accident>();

            using (var streamReader = new StreamReader(fileLocation))
            {
                string currentLine;

                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    var columns = currentLine.Split(',');
                    if (columns[0] == "Accident_Index")
                    {
                        continue;
                    }

                    var accident = GenerateAccident(columns);

                    accidentList.Add(accident);
                    if (currentCount == lastSave + 50000)
                    {
                        using (var dbContext = new DatabaseContext())
                        {
                            dbContext.AddRange(accidentList);
                            dbContext.SaveChanges();
                            accidentList.Clear();
                        }
                        lastSave += 50000;
                    }

                    currentCount++;
                    Console.Write(currentCount);
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                using (var dbContext = new DatabaseContext())
                {
                    dbContext.Accidents.AddRange(accidentList);
                    dbContext.SaveChanges();
                }

            }
        }

        private static Accident GenerateAccident(string[] columns)
        {
            return new Accident
            {
                Accident_Index = columns[0],
                Location_Easting_OSGR = columns[1].ConvertToNullableInt(),
                Location_Northing_OSGR = columns[2].ConvertToNullableInt(),
                Longitude = columns[3].ConvertToNullableDecimal(),
                Latitude = columns[4].ConvertToNullableDecimal(),
                Police_Force = int.Parse(columns[5]),
                Accident_Severity = int.Parse(columns[6]),
                Number_of_Vehicles = int.Parse(columns[7]),
                Number_of_Casualties = int.Parse(columns[8]),
                Date = DateTime.Parse(columns[9]),
                Day_of_Week = int.Parse(columns[10]),
                Time = columns[11].ConvertToNullableTimeSpan(),
                Local_Authority_District = int.Parse(columns[12]),
                Local_Authority_Highway = columns[13],
                First_Road_Class = int.Parse(columns[14]),
                First_Road_Number = int.Parse(columns[15]),
                Road_Type = int.Parse(columns[16]),
                Speed_Limit = int.Parse(columns[17]),
                Junction_Detail = int.Parse(columns[18]),
                Junction_Control = int.Parse(columns[19]),
                Second_Road_Class = int.Parse(columns[20]),
                Second_Road_Number = int.Parse(columns[21]),
                Pedestrian_Crossing_Human_Control = int.Parse(columns[22]),
                Pedestrian_Crossing_Physical_Facilities = int.Parse(columns[23]),
                Light_Conditions = int.Parse(columns[24]),
                Weather_Conditions = int.Parse(columns[25]),
                Road_Surface_Conditions = int.Parse(columns[26]),
                Special_Conditions_at_Site = int.Parse(columns[27]),
                Carriageway_Hazards = int.Parse(columns[28]),
                Urban_or_Rural_Area = int.Parse(columns[29]),
                Police_Attended_Scene = int.Parse(columns[30]),
                LOSA_of_Accident_Location = columns[31]
            };
        }
    }
}
