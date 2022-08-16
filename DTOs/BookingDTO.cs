namespace TestHotel.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfRooms { get; set; }
        public long Price { get; set; }
        public int CustomerId { get; set; }
        public int? CustomerName { get; set; }



    }
}
