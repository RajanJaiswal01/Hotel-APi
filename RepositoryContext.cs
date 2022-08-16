using Microsoft.EntityFrameworkCore;
using TestHotel.Entities;

namespace TestHotel
{
    public class RepositoryContext:DbContext

    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<HotelStaff> HotelStaff { get; set; }


    }


}
