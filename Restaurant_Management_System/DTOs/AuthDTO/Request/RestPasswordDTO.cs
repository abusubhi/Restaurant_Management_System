namespace Restaurant_Management_System.DTOs.AuthDTO.Request
{
    public class RestPasswordDTO
    {
       
            public string Email { get; set; }
            public int OTPCode { get; set; }
            public string NewPassword { get; set; }
        
    }
}
