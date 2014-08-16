CREATE TABLE [dbo].[PerformanceRating]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] VARCHAR(50) NULL, 
    [Rating] TINYINT NULL, 
    [Comments] TEXT NULL, 
    [IsPublic] BIT NULL, 
    [PerformanceId] INT NULL, 
    CONSTRAINT [FK_PerformanceRating_Performance] FOREIGN KEY (PerformanceId) REFERENCES Performance(Id)
)
