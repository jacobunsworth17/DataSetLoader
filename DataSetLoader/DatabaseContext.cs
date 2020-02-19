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
}
