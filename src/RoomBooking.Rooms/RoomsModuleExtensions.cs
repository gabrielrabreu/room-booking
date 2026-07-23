using RoomBooking.Rooms.Data;

namespace RoomBooking.Rooms;

public static class RoomsModuleExtensions
{
    public static IServiceCollection AddRoomsModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RoomsDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("RoomsDb")));

        return services;
    }

    public static async Task<IServiceProvider> EnsureRoomsModuleDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RoomsDbContext>();
        await context.Database.MigrateAsync();

        return services;
    }
}
