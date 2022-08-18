namespace TestHotel.DTOs
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string Occupied { get; set; }
        public long Price { get; set; }
        public string TypeOfRoom { get; set; }
        public int? BookingId { get; set; }
        public string? imagePath { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

    }
}
