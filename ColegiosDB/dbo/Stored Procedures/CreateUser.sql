CREATE PROCEDURE [dbo].[CreateUser]
(
	@Names NVARCHAR(50),
	@LastNames NVARCHAR(50),
	@birthday DATE,
	@PhoneNumber NVARCHAR(20),
	@IdRol INT,
	@EntryDate DATE,
	@Status BIT,
	@UserName NVARCHAR(50),
	@Password NVARCHAR(100),
	@PasswordSalt NVARCHAR(100)
)
AS
BEGIN
DECLARE @IsSuccess BIT
DECLARE @Message NVARCHAR(MAX)
	BEGIN TRY
		INSERT INTO Users 
		(Names,
		 LastNames,
		 birthday,
		 PhoneNumber,
		 IdRol,
		 EntryDate,
		 [Status],
		 UserName,
		 [Password],
		 PasswordSalt
		)
		VALUES
		(
		 @Names,
		 @LastNames,
		 @birthday,
		 @PhoneNumber,
		 @IdRol,
		 @EntryDate,
		 @Status,
		 @UserName,
		 @Password,
		 @PasswordSalt
		)
		SET @IsSuccess = 1
		SET @Message ='Usuario Creado con exito'	
	END TRY
	BEGIN CATCH
		SET @IsSuccess = 0
		SET @Message = ERROR_MESSAGE()
	END CATCH
 SELECT @IsSuccess AS IsSuccess, @Message AS [Message]	 
END
