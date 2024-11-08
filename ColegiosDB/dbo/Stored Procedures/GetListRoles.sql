CREATE PROCEDURE GetListRoles
(
	@PageIndex  INT = 1,
	@PageSize INT = 10,
	@Description NVARCHAR(50)
)
AS
BEGIN
	SELECT R.IdRol,R.[Description] FROM Roles R WHERE (@Description IS NULL OR R.[Description] LIKE '%' + @Description + '%')
ORDER BY R.IdRol OFFSET(@PageIndex - 1) * @PageSize ROWS
	 FETCH NEXT @PageSize ROWS ONLY;
	 SELECT COUNT(*) AS TotalRecords
      FROM Roles R
	 WHERE  (@Description IS NULL OR R.Description LIKE '%' + @Description + '%')
END

