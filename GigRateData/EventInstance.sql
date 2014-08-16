CREATE TABLE [dbo].[EventInstance]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EventId] INT NULL, 
	[Name] VARCHAR(255) NULL,
    [DateFrom] DATE NULL, 
    [DateTo] DATE NULL, 
    CONSTRAINT [FK_EventInstance_Event] FOREIGN KEY (EventId) REFERENCES Event(Id)
)
