namespace RoomBooking.Rooms.Features.CreateRoom;

public static class CreateRoomEndpoint
{
    public static RouteGroupBuilder MapCreateRoomEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateRoomRequest request, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var command = new CreateRoomCommand(request.Name);

            var result = await mediator.Send(command, cancellationToken);

            return result.ToCreated(room => $"/rooms/{room.Id}");
        })
        .WithName("CreateRoom");

        return group;
    }
}
