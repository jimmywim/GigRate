﻿CREATE TABLE [dbo].[Act]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NULL, 
    [GenreId] INT NULL, 
    CONSTRAINT [FK_Act_Genre] FOREIGN KEY ([GenreId]) REFERENCES [Genre](Id)
)
