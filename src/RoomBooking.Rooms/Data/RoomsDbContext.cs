namespace RoomBooking.Rooms.Data;

public class RoomsDbContext(DbContextOptions<RoomsDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Rooms");
    }
}
