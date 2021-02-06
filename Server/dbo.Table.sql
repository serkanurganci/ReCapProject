CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] INT NOT NULL, 
    [DailyPrice] DECIMAL NOT NULL, 
    [Description] VARCHAR(50) NOT NULL
)
