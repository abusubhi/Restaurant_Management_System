namespace Restaurant_Management_System.DTOs.AuthDTO.Request
{
    public class VerifyDTO
    {
        public string Email { get; set; }
        public int OTPCode { get; set; }
    }
}
