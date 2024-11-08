CREATE TABLE [dbo].[Users] (
    [IdUser]       INT            IDENTITY (1, 1) NOT NULL,
    [Names]        NVARCHAR (50)  NULL,
    [LastNames]    NVARCHAR (50)  NULL,
    [birthday]     DATE           NULL,
    [PhoneNumber]  NVARCHAR (20)  NULL,
    [IdRol]        INT            NULL,
    [EntryDate]    DATE           NULL,
    [Status]       BIT            NULL,
    [UserName]     NVARCHAR (50)  NULL,
    [Password]     NVARCHAR (100) NULL,
    [PasswordSalt] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([IdUser] ASC),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([IdRol])
);

