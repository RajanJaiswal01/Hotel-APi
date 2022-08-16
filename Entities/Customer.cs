namespace TestHotel.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Citizenship { get; set; }
        public DateTime RegisteredDate { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Booking> bookings { get; set; }
    }
}
