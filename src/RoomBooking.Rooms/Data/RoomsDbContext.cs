using RoomBooking.Rooms.Models;

namespace RoomBooking.Rooms.Data;

public class RoomsDbContext(DbContextOptions<RoomsDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms => Set<Room>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Rooms");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoomsDbContext).Assembly);
    }
}
