CREATE TABLE [dbo].[Roles] (
    [IdRol]       INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (20) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([IdRol] ASC)
);

