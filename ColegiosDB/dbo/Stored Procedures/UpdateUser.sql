CREATE PROCEDURE [dbo].[UpdateUser]
(
    @IdUser INT,
	@Names NVARCHAR(50),
    @LastNames NVARCHAR(50),
	@birthday DATE,
	@PhoneNumber NVARCHAR(20),
	@IdRol INT,
	@EntryDate DATE,
	@Status BIT,
	@UserName NVARCHAR(50)
)
AS
BEGIN
DECLARE @IsSuccess BIT
DECLARE @Message NVARCHAR(MAX)
	BEGIN TRY
	 UPDATE Users SET
		Names       = @Names,
		LastNames   = @LastNames,
		birthday    = @birthday,
		PhoneNumber = @PhoneNumber,
		IdRol       = @IdRol,
		EntryDate   = @EntryDate,
		[Status]    = @Status,
		UserName    = @UserName
	WHERE IdUser = @IdUser
		SET @IsSuccess = 1
		SET @Message ='Usuario actualizado con exito'	
	END TRY
	BEGIN CATCH
		SET @IsSuccess = 0
		SET @Message = ERROR_MESSAGE()
	END CATCH
 SELECT @IsSuccess AS IsSuccess, @Message AS [Message]	 
END
