

CREATE PROCEDURE Auth 
(
   @UserName VARCHAR(50)
)
AS
BEGIN
 select * FROM Users  where UserName = @UserName;
END