using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Restaurant_Management_System.DTOs.AuthDTO.Request;
using Restaurant_Management_System.DTOs.AuthDTO.Response;
using System.Data;
using System.Net.Mail;
using System.Net;
using Restaurant_Management_System.Helper;
using Restaurant_Management_System.Models;
using Azure;
namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _connectionString;

      

        public AuthController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            
        }


        [HttpPost]
        [Route("Generate OTP")]

        public async Task<IActionResult> GenerateOTP([FromBody] string Email)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(Email))
                    throw new Exception("Email and Password are required");


                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("GenerateOTP", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", Email);

                await sqlConnection.OpenAsync();
                var resulte = await command.ExecuteNonQueryAsync();
                
                return Ok(new
                {
                    OTP = resulte,
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("RestPassword")]

        public async Task<IActionResult> RestPassword([FromBody] RestPasswordDTO input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.NewPassword) || input.ConfirmNewPassword != input.NewPassword)
                    throw new Exception("Email and Password are required");


                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("ResetPassword1", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email",input.Email);
                command.Parameters.AddWithValue("@OTPCode", input.OTPCode);
                command.Parameters.AddWithValue("@NewPassword", input.NewPassword);

                await sqlConnection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    // Ensure the reader has enough columns
                    if (reader.FieldCount >= 2)
                    {
                        int result = reader.GetInt32(0); // success flag
                        int userId = reader.GetInt32(1); // returned UserId

                        if (result == 1)
                        {
                            var user = new User
                            {
                                UserId = userId,
                                Email = input.Email,
                                IsActive = true
                            };
                            var token = TokenHelper.GenerateJwtToken(user);
                            return Ok(new { message = "Password reset successful.", token });
                        }
                        else
                        {
                            return BadRequest("Invalid or expired OTP.");
                        }
                    }
                    else
                    {
                        return StatusCode(500, "Stored procedure did not return expected data.");
                    }
                }
                else
                {
                    return StatusCode(500, "No data returned from stored procedure.");
                }
            
                return StatusCode(500, "Unexpected response from server.");
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex.Message);
            }

        }


        [HttpPost("MyCreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] SignUpDTO user)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("CREATE_NEW_USER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@UserName", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@UserRoleId", user.UserRoleId);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                        command.Parameters.AddWithValue("@Image", user.Image ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);

                       
                        command.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        await command.ExecuteNonQueryAsync();

                        int newUserId = Convert.ToInt32(command.Parameters["@UserId"].Value);

                        var user1 = new User
                        {
                            UserId = newUserId,
                            Email = user.Email,
                            IsActive = true
                        };
                       var Token = TokenHelper.GenerateJwtToken(user1);
                       
                       

                        return Ok(new { message = "user created successfully " , token = Token});
                    }

                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new { Message = "Database error", Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred", Error = ex.Message });
            }
        }

        //login
        [HttpPost("login")]
        public async Task<IActionResult> SignIn(LoginDTO input)
        {
            var response = new LoginResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
                    throw new Exception("Email and Password are required");

               

                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand command = new SqlCommand("User_Login", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", input.Email);
                command.Parameters.AddWithValue("@Password", input.Password);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                    throw new Exception("Invalid Email / Password");

                if (dataTable.Rows.Count > 1)
                    throw new Exception("Query Contains More Than One Element");


                DataRow row = dataTable.Rows[0];

                var user = new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Email = input.Email,
                    IsActive = Convert.ToBoolean(row["IsActive"])
                };

                response.UserId = user.UserId;
                response.Username = row["Username"].ToString();
                response.Token = TokenHelper.GenerateJwtToken(user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }


    }
}
