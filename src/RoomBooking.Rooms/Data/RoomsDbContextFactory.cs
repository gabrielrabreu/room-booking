namespace RoomBooking.Rooms.Data;

public class RoomsDbContextFactory : IDesignTimeDbContextFactory<RoomsDbContext>
{
    public RoomsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RoomsDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RoomsDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new RoomsDbContext(optionsBuilder.Options);
    }
}
