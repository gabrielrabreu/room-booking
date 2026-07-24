using RoomBooking.Rooms.Data;
using RoomBooking.Rooms.Models;

namespace RoomBooking.Rooms.Features.CreateRoom;

public class CreateRoomHandler(RoomsDbContext dbContext) : ICommandHandler<CreateRoomCommand, ErrorOr<RoomDetailsResponse>>
{
    public async ValueTask<ErrorOr<RoomDetailsResponse>> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        var room = new Room(command.Name);

        dbContext.Rooms.Add(room);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new RoomDetailsResponse(room.Id, room.Name, room.CreatedAt, room.UpdatedAt);
    }
}
