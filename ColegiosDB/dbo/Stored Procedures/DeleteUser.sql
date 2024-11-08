CREATE PROCEDURE DeleteUser
(
	@IdUser INT
)
AS
BEGIN
	DECLARE @IsSuccess BIT
	DECLARE @Message NVARCHAR(MAX)
	BEGIN TRY
	 DELETE FROM Users WHERE IdUser = @IdUser
		SET @IsSuccess = 1
		SET @Message ='Usuario eliminado con exito'	
	END TRY
	BEGIN CATCH
		SET @IsSuccess = 0
		SET @Message = ERROR_MESSAGE()
	END CATCH
 SELECT @IsSuccess AS IsSuccess, @Message AS [Message]	 

END
