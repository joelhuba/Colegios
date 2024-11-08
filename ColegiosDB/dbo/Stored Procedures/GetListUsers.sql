CREATE PROCEDURE [dbo].[GetListUsers]
(
    @PageIndex  INT = 1,
	@PageSize INT = 10,
	@Status BIT,
	@Name NVARCHAR(50),
	@Description NVARCHAR(20)
)
AS 
BEGIN
	SELECT U.IdUser,U.Names,U.LastNames,U.birthday,U.PhoneNumber,R.[Description],U.EntryDate,U.[Status],U.UserName FROM  Users U JOIN Roles R ON R.IdRol = U.IdRol
	 WHERE
      (@Status IS NULL OR U.[Status] = @Status)  AND (@Name IS NULL OR U.Names LIKE '%' + @Name + '%') AND (@Description IS NULL OR R.[Description] LIKE '%' + @Description + '%') 
	ORDER BY U.IdUser OFFSET(@PageIndex - 1) * @PageSize ROWS
	 FETCH NEXT @PageSize ROWS ONLY;
	 SELECT COUNT(*) AS TotalRecords
      FROM Users U
	 WHERE  [Status] = 1 
END
