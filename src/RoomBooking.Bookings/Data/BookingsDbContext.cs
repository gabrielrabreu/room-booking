namespace RoomBooking.Bookings.Data;

public class BookingsDbContext(DbContextOptions<BookingsDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Bookings");
    }
}
