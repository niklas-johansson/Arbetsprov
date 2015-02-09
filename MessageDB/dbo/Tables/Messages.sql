CREATE TABLE [dbo].[Messages] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Text]      NVARCHAR (MAX) NULL,
    [TimeStamp] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

