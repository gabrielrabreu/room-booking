using RoomBooking.Rooms.Data;
using RoomBooking.Rooms.Features.CreateRoom;

namespace RoomBooking.Rooms;

public static class RoomsModuleExtensions
{
    public static IServiceCollection AddRoomsModuleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RoomsDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("RoomsDb")));

        services.AddValidatorsFromAssemblyContaining<CreateRoomValidator>();

        return services;
    }

    public static IEndpointRouteBuilder MapRoomsModuleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/rooms")
            .WithTags("Rooms");

        group.MapCreateRoomEndpoint();

        return app;
    }

    public static async Task<IServiceProvider> EnsureRoomsModuleDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RoomsDbContext>();
        await context.Database.MigrateAsync();

        return services;
    }
}
