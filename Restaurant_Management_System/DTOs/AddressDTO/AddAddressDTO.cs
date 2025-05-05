namespace Restaurant_Management_System.DTOs.AddressDTO
{
    public class AddAddressDTO
    {
        public string Province { get; set; } = null!;

        public string Region { get; set; } = null!;

        public string? AddressHint { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? UpdationDate { get; set; }

        public bool? IsActive { get; set; }

        public int UserId { get; set; }
    }
}
