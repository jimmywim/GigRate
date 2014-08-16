CREATE TABLE [dbo].[Performance]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TimeOn] DATETIME NULL, 
    [TimeOff] DATETIME NULL, 
    [ActId] INT NULL, 
    [EventInstanceStageId] INT NULL, 
    CONSTRAINT [FK_Performance_Act] FOREIGN KEY (ActId) REFERENCES Act(Id), 
    CONSTRAINT [FK_Performance_EventInstanceStage] FOREIGN KEY (EventInstanceStageId) REFERENCES EventInstanceStages(Id)
)
