namespace RoomBooking.Rooms.Features.GetRoomById;

public static class GetRoomByIdEndpoint
{
    public static RouteGroupBuilder MapGetRoomByIdEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new GetRoomByIdQuery(id);

            var result = await mediator.Send(query, cancellationToken);

            return result.ToOk();
        })
        .WithName("GetRoomById");

        return group;
    }
}
