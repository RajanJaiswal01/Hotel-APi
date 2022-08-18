﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TestHotel.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string Occupied { get; set; }
        public long Price { get; set; }
        public string TypeOfRoom { get; set; }
        public int? BookingId { get; set; }
        public string? imagePath { get; set; }

        [ForeignKey("BookingId")]
        public virtual Booking? Bookings { get; set; }
    }
}
