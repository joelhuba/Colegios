CREATE PROCEDURE DeleteRol
(
	@IdRol INT
)
AS
BEGIN
DECLARE @IsSuccess BIT
DECLARE @Message NVARCHAR(MAX)
	BEGIN TRY
		DELETE FROM Roles WHERE IdRol = @IdRol
			SET @IsSuccess = 1
			SET @Message ='Rol eliminado con exito'	
	END TRY
	BEGIN CATCH
	SET @IsSuccess = 0
	SET @Message = ERROR_MESSAGE()
	END CATCH
 SELECT @IsSuccess AS IsSuccess, @Message AS [Message]	 
END
