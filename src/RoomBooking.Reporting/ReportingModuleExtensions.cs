using RoomBooking.Reporting.Data;

namespace RoomBooking.Reporting;

public static class ReportingModuleExtensions
{
    public static IServiceCollection AddReportingModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReportingDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("ReportingDb")));

        return services;
    }

    public static async Task<IServiceProvider> EnsureReportingModuleDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ReportingDbContext>();
        await context.Database.MigrateAsync();

        return services;
    }
}
