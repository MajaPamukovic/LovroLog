USE LovroLog
GO

-- Function to be called after any of the 3 actions: INSERT, DELETE, UPDATE
CREATE PROCEDURE PROC_UpdateDbSummary --[dbo].[LovroLog] (@fakeInputVariable INT) --(@AsOfDate DATETIME)
AS
BEGIN
DECLARE @summaryID INTEGER = NULL;
SELECT @summaryID = (SELECT TOP(1) [ID] FROM [dbo].[DatabaseSummaries]);
IF @summaryID IS NULL INSERT INTO [dbo].[DatabaseSummaries] (ID, LastModified) VALUES (1, GETDATE())
ELSE UPDATE [dbo].[DatabaseSummaries] SET [LastModified] = GETDATE() WHERE [ID] = 1;
END
GO

-- Trigger to be executed when an entry is inserted into the LovroBaseEvents table
CREATE TRIGGER TRIGGER_AfterInsert 
ON [dbo].[LovroBaseEvents]
AFTER INSERT AS
BEGIN
EXEC PROC_UpdateDbSummary;
END
GO

-- Trigger to be executed when an entry is updated in the LovroBaseEvents table
CREATE TRIGGER TRIGGER_AfterUpdate
ON [dbo].[LovroBaseEvents]
AFTER UPDATE AS
BEGIN
EXEC PROC_UpdateDbSummary;
END
GO

-- Trigger to be executed when an entry is deleted from the LovroBaseEvents table
CREATE TRIGGER TRIGGER_AfterDelete
ON [dbo].[LovroBaseEvents]
AFTER DELETE AS
BEGIN
EXEC PROC_UpdateDbSummary;
END
GO