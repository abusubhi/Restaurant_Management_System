
CREATE OR ALTER PROCEDURE CREATE_NEW_USER 
    @FirstName      VARCHAR(255),
    @LastName       VARCHAR(255),
    @UserName       VARCHAR(50), 
    @Password       VARCHAR(100),
    @UserRoleId     INT,
    @Email          VARCHAR(255),
    @PhoneNumber    VARCHAR(10),
    @Image          VARCHAR(255) = NULL,
    @CreatedBy      VARCHAR(255),
    @UpdatedBy      VARCHAR(255) = NULL,
    @CreationAt     DATETIME = NULL,
    @UpdationAt     DATETIME = NULL,
    @isActive       BIT = 1,
    @isVerified     BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate input lengths match table definitions
    IF LEN(@PhoneNumber) > 10
    BEGIN
        RAISERROR('Phone number cannot exceed 10 characters', 16, 1);
        RETURN;
    END

    IF LEN(@UserName) > 50
    BEGIN
        RAISERROR('Username cannot exceed 50 characters', 16, 1);
        RETURN;
    END

    IF @CreationAt IS NULL
        SET @CreationAt = GETDATE();

    BEGIN TRY
        INSERT INTO Users (
            FirstName, LastName, Username, [Password], UserRoleId,
            Email, PhoneNumber, Profile_Image,
            CreatedBy, UpdatedBy, CreationDate, UpdationDate,
            isActive, isVerified
        )
        VALUES (
            @FirstName, @LastName, @UserName, @Password, @UserRoleId,
            @Email, @PhoneNumber, @Image,
            @CreatedBy, @UpdatedBy, @CreationAt, @UpdationAt,
            @isActive, @isVerified
        );
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

EXEC CREATE_NEW_USER 
    @FirstName = 'Ahmad',
    @LastName = 'Yousef',
    @UserName = 'ahmadYUSEF',
    @Password = 'Ahmad@12342',
    @UserRoleId = 1,
    @Email = 'ahmad@gmail.com',
    @PhoneNumber = '0779988776',
    @Image = 'ahmad.jpg',
    @CreatedBy = 'admin',
    @UpdatedBy = 'admin';


	SELECT * FROM Users