CREATE PROCEDURE CreateRol
(
  @Description NVARCHAR(20)
)
AS
BEGIN
DECLARE @IsSuccess BIT
DECLARE @Message NVARCHAR(MAX)
	BEGIN TRY
		INSERT INTO Roles ([Description]) VALUES (@Description)
		SET @IsSuccess = 1
		SET @Message ='Rol creado con exito'	
	END TRY
	BEGIN CATCH
	SET @IsSuccess = 0
	SET @Message = ERROR_MESSAGE()
	END CATCH
 SELECT @IsSuccess AS IsSuccess, @Message AS [Message]	 
END
