namespace TestHotel.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public string isprinted { get; set; }
        public int CustomerId { get; set; } 
        public int BookingId { get; set; }  
        public int TotalPrice { get; set; }
        public int? CustomerName { get; set; }

    }
}
