using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Restaurant_Management_System.DTOs.AuthDTO.Request;
using Restaurant_Management_System.DTOs.AuthDTO.Response;
using System.Data;
namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        [Route("Generate OTP")]

        public async Task<IActionResult> GenerateOTP([FromBody] string Email)
        {

            try
            {
                string connectionString = "Data Source=LAPTOP-QGFR6N5D;Initial Catalog=RMS;Integrated Security=True;Trust Server Certificate=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
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
                string connectionString = "Data Source=LAPTOP-QGFR6N5D;Initial Catalog=RMS;Integrated Security=True;Trust Server Certificate=True";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("ResetPassword", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email",input.Email);
                command.Parameters.AddWithValue("@OTPCode", input.OTPCode);
                command.Parameters.AddWithValue("@NewPassword", input.NewPassword);

                await sqlConnection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                
                if (await reader.ReadAsync())
                {
                    return Ok("Update Successful");
                }
                
                return StatusCode(200, "Update Successful");
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex.Message);
            }

        }


        [HttpPost("MyCreateUser")]
        public IActionResult CreateUser([FromBody] SignUpDTO user)
        {
            string connectionString = "Data Source=DESKTOP-8T8OGPF;Initial Catalog=RMS;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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

                        command.ExecuteNonQuery();

                        return Ok(new { Message = "User created successfully" });
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


        [HttpPost("login")]
        public async Task<IActionResult> SignIn(LoginDTO input)
        {
            var response = new LoginResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Password))
                    throw new Exception("Email and Password are required");

                string connectionString = "Data Source=DESKTOP-D89OGE0\\SQLEXPRESS;Initial Catalog=RMS-;Integrated Security=True;Trust Server Certificate=True";

                SqlConnection connection = new SqlConnection(connectionString);
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


                foreach (DataRow row in dataTable.Rows)
                {
                    response.UserId = Convert.ToInt32(row["UserId"]);
                    response.Username = row["Username"].ToString();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

    }
}
