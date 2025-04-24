CREATE OR ALTER PROCEDURE User_Login
    @Email VARCHAR(255),
    @Password VARCHAR(100)
AS
BEGIN
    SELECT UserId AS UserId, Username
    FROM Users
    WHERE Email = @Email AND [Password] = @Password
END

