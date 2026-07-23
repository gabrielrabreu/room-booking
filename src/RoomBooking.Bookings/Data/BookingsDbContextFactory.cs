namespace RoomBooking.Bookings.Data;

public class BookingsDbContextFactory : IDesignTimeDbContextFactory<BookingsDbContext>
{
    public BookingsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookingsDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookingsDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new BookingsDbContext(optionsBuilder.Options);
    }
}
