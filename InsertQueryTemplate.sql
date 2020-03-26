USE [LunarSportsDBContext-5]
GO

/****** Object: Table [dbo].[EventLocations] Script Date: 11/03/2020 03:43:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
BULK INSERT[dbo].[EventScheduleEntries]
FROM 'C:\Users\Madero\source\repos\LunarSports\CSV\_EventScheduleEntry.csv'
WITH
(
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',  --CSV field delimiter
    ROWTERMINATOR = '\n',   --Use to shift the control to next row
    TABLOCK
)


