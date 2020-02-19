using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataSetLoader
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Accident> Accidents { get; set; }
        public DbSet<Casualty> Casualties { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AI_ML_DataSet;Trusted_Connection=True;");
    }

    public class Accident
    {
        [Key]
        public string Accident_Index { get; set; }
        public int? Location_Easting_OSGR { get; set; }
        public int? Location_Northing_OSGR { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public int Police_Force { get; set; }
        public int Accident_Severity { get; set; }
        public int Number_of_Vehicles { get; set; }
        public int Number_of_Casualties { get; set; }
        public DateTime Date { get; set; }
        public int Day_of_Week { get; set; }
        public TimeSpan? Time { get; set; }
        public int Local_Authority_District { get; set; }
        public string Local_Authority_Highway { get; set; }
        public int First_Road_Class { get; set; }
        public int First_Road_Number { get; set; }
        public int Road_Type { get; set; }
        public int Speed_Limit { get; set; }
        public int Junction_Detail { get; set; }
        public int Junction_Control { get; set; }
        public int Second_Road_Class { get; set; }
        public int Second_Road_Number { get; set; }
        public int Pedestrian_Crossing_Human_Control { get; set; }
        public int Pedestrian_Crossing_Physical_Facilities { get; set; }
        public int Light_Conditions { get; set; }
        public int Weather_Conditions { get; set; }
        public int Road_Surface_Conditions { get; set; }
        public int Special_Conditions_at_Site { get; set; }
        public int Carriageway_Hazards { get; set; }
        public int Urban_or_Rural_Area { get; set; }
        public int Police_Attended_Scene { get; set; }
        public string LOSA_of_Accident_Location { get; set; }

    }

    public class Casualty
    {
        [Key]
        public Guid Casualty_Id { get; set; }
        public string Accident_Index { get; set; }
        public int? Vehicle_Reference { get; set; }
        public int? Casualty_Reference { get; set; }
        public int? Casualty_Class { get; set; }
        public int? Sex_of_Casualty { get; set; }
        public int? Age_of_Casualty { get; set; }
        public int? Age_Band_of_Casualty { get; set; }
        public int? Casualty_Severity { get; set; }
        public int? Pedestrian_Location { get; set; }
        public int? Pedestrian_Movement { get; set; }
        public int? Car_Passenger { get; set; }
        public int? Bus_or_Coach_Passenger { get; set; }
        public int? Pedestrian_Road_Maintenance_Worker { get; set; }
        public int? Casualty_Type { get; set; }
        public int? Casualty_Home_Area_Type { get; set; }
    }

    public class Vehicle
    {
        [Key]
        public Guid Vehicle_Id { get; set; }
        public string Accident_Index { get; set; }
        public int? Vehicle_Reference { get; set; }
        public int? Vehicle_Type { get; set; }
        public int? Towing_and_Articulation { get; set; }
        public int? Vehicle_Manoeuvre { get; set; }
        public int? Vehicle_Location_Restricted_Lane { get; set; }
        public int? Junction_Location { get; set; }
        public int? Skidding_and_Overturning { get; set; }
        public int? Hit_Object_off_Carriageway { get; set; }
        public int? First_Point_of_Impact { get; set; }
        public int? Was_Vehicle_Left_Hand_Driven { get; set; }
        public int? Journey_Purpose_of_Driver { get; set; }
        public int? Sex_of_Driver { get; set; }
        public int? Age_of_Driver { get; set; }
        public int? Age_Band_of_Driver { get; set; }
        public int? Engine_Capacity_CC { get; set; }
        public int? Propulsion_Code { get; set; }
        public int? Age_of_Vehicle { get; set; }
        public int? Driver_IMD_Decile { get; set; }
        public int? Driver_Home_Area_Type { get; set; }
    }
}
