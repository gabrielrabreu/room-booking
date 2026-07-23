using RoomBooking.Users.Data;

namespace RoomBooking.Users;

public static class UsersModuleExtensions
{
    public static IServiceCollection AddUsersModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UsersDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("UsersDb")));

        return services;
    }

    public static async Task<IServiceProvider> EnsureUsersModuleDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
        await context.Database.MigrateAsync();

        return services;
    }
}
