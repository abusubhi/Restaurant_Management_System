using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Restaurant_Management_System.DTOs.AuthDTO.Request;
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
    }
}
