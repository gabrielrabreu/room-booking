namespace RoomBooking.Rooms.Features.ListRooms;

public static class ListRoomsEndpoint
{
    public static RouteGroupBuilder MapListRoomsEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new ListRoomsQuery();

            var result = await mediator.Send(query, cancellationToken);

            return result.ToOk();
        })
        .WithName("ListRooms");

        return group;
    }
}
