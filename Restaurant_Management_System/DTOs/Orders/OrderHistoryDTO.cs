namespace Restaurant_Management_System.DTOs.Orders
{
    public class OrderHistoryDTO
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
