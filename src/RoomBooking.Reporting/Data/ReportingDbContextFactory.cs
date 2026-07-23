namespace RoomBooking.Reporting.Data;

public class ReportingDbContextFactory : IDesignTimeDbContextFactory<ReportingDbContext>
{
    public ReportingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ReportingDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReportingDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new ReportingDbContext(optionsBuilder.Options);
    }
}

