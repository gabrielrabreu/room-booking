using RoomBooking.Bookings.Data;

namespace RoomBooking.Bookings;

public static class BookingsModuleExtensions
{
    public static IServiceCollection AddBookingsModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookingsDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("BookingsDb")));

        return services;
    }

    public static async Task<IServiceProvider> EnsureBookingsModuleDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BookingsDbContext>();
        await context.Database.MigrateAsync();

        return services;
    }
}
