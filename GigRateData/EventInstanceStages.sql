CREATE TABLE [dbo].[EventInstanceStages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StageId] INT NULL, 
    [EventInstanceId] INT NULL, 
    CONSTRAINT [FK_EventInstanceStages_Stage] FOREIGN KEY (StageId) REFERENCES Stage(Id), 
    CONSTRAINT [FK_EventInstanceStages_EventInstance] FOREIGN KEY ([EventInstanceId]) REFERENCES EventInstance(Id)
)
