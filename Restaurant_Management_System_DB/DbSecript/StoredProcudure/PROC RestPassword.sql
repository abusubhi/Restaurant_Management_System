create proc Rest_Password 
@Email VARCHAR(255),
@NewPassword1 NVARCHAR(255),
@NewPassword2 NVARCHAR(255)
AS 
Begin

select 1 from Users where Email = @Email and  @NewPassword1 = @NewPassword2
UPDATE Users
    SET [Password] = @NewPassword1
    WHERE Email = @Email;
end

Exec Rest_Password 
	@Email = 'john@gmail.com',
	@NewPassword1 = 'Ahmad@00000',
	@NewPassword2 = 'Ahmad@00000';
    