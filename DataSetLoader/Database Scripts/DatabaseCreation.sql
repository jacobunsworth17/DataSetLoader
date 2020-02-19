USE master
IF EXISTS(select * from sys.databases where name='AI_ML_DataSet')
BEGIN
ALTER DATABASE AI_ML_DataSet SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE AI_ML_DataSet
END

CREATE DATABASE AI_ML_DataSet;
GO
USE AI_ML_DataSet;
GO

CREATE TABLE Accidents(
	Accident_Index VARCHAR(16) NOT NULL PRIMARY KEY,
	Location_Easting_OSGR INT,
	Location_Northing_OSGR INT,
	Longitude DECIMAL(12),
	Latitude DECIMAL(12),
	Police_Force INT,
	Accident_Severity INT,
	Number_of_Vehicles INT,
	Number_of_Casualties INT,
	[Date] DATE,
	Day_of_Week INT,
	[Time] TIME,
	Local_Authority_District INT,
	Local_Authority_Highway VARCHAR(12),
	First_Road_Class INT,
	First_Road_Number INT,
	Road_Type INT,
	Speed_Limit INT,
	Junction_Detail INT,
	Junction_Control INT,
	Second_Road_Class INT,
	Second_Road_Number INT,
	Pedestrian_Crossing_Human_Control INT,
	Pedestrian_Crossing_Physical_Facilities INT,
	Light_Conditions INT,
	Weather_Conditions INT,
	Road_Surface_Conditions INT,
	Special_Conditions_at_Site INT,
	Carriageway_Hazards INT,
	Urban_or_Rural_Area INT,
	Police_Attended_Scene INT,
	LOSA_of_Accident_Location VARCHAR(12)
);
GO

CREATE TABLE Casualties(
	Casualty_Id uniqueidentifier NOT NULL PRIMARY KEY,
	Accident_Index VARCHAR(16) NOT NULL,
	Vehicle_Reference INT,
	Casualty_Reference INT,
	Casualty_Class INT,
	Sex_of_Casualty INT,
	Age_of_Casualty INT,
	Age_Band_of_Casualty INT,
	Casualty_Severity INT,
	Pedestrian_Location INT,
	Pedestrian_Movement INT,
	Car_Passenger INT,
	Bus_or_Coach_Passenger INT,
	Pedestrian_Road_Maintenance_Worker INT,
	Casualty_Type INT,
	Casualty_Home_Area_Type INT
);
GO

CREATE TABLE Vehicles(
	Vehicle_Id uniqueidentifier NOT NULL PRIMARY KEY,
	Accident_Index VARCHAR(16) NOT NULL,
	Vehicle_Reference INT,
	Vehicle_Type INT,
	Towing_and_Articulation INT,
	Vehicle_Manoeuvre INT,
	Vehicle_Location_Restricted_Lane INT,
	Junction_Location INT,
	Skidding_and_Overturning INT,
	Hit_Object_off_Carriageway INT,
	First_Point_of_Impact INT,
	Was_Vehicle_Left_Hand_Driven INT,
	Journey_Purpose_of_Driver INT,
	Sex_of_Driver INT,
	Age_of_Driver INT,
	Age_Band_of_Driver INT,
	Engine_Capacity_CC INT,
	Propulsion_Code INT,
	Age_of_Vehicle INT,
	Driver_IMD_Decile INT,
	Driver_Home_Area_Type INT
);
GO