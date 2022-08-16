namespace TestHotel.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfRooms { get; set; }
        public long Price { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }


}
