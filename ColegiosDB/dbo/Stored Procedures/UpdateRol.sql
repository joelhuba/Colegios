CREATE PROCEDURE UpdateRol
(
	@IdRol INT,
	@Description NVARCHAR(20)
)
AS
BEGIN
DECLARE @IsSuccess BIT
DECLARE @Message NVARCHAR(MAX)
	BEGIN TRY
	  UPDATE Roles SET [Description] = @Description WHERE IdRol = @IdRol 
	  	SET @IsSuccess = 1
		SET @Message ='Rol actualizado con exito'	
	END TRY
	BEGIN CATCH
	SET @IsSuccess = 0
	SET @Message = ERROR_MESSAGE()
	END CATCH
 SELECT @IsSuccess AS IsSuccess, @Message AS [Message]	 
END
