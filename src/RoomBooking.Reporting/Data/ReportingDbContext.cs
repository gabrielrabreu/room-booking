namespace RoomBooking.Reporting.Data;

public class ReportingDbContext(DbContextOptions<ReportingDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Reporting");
    }
}

