using System.ComponentModel.DataAnnotations.Schema;

namespace TestHotel.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string isprinted { get; set; }
        public int CustomerId { get; set; }
        public int BookingId { get; set; }
        public long TotalPrice { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer customer { get; set; }
        public virtual Booking bookings { get; set; }
       

    }
}
