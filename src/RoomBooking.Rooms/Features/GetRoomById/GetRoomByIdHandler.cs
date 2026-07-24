using RoomBooking.Rooms.Data;

namespace RoomBooking.Rooms.Features.GetRoomById;

public class GetRoomByIdHandler(RoomsDbContext dbContext) : IQueryHandler<GetRoomByIdQuery, ErrorOr<RoomDetailsResponse>>
{
    public async ValueTask<ErrorOr<RoomDetailsResponse>> Handle(GetRoomByIdQuery query, CancellationToken cancellationToken)
    {
        var room = await dbContext.Rooms
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == query.Id, cancellationToken);

        if (room is null)
        {
            return Error.NotFound("Room.NotFound", $"Room with ID '{query.Id}' was not found.");
        }

        return new RoomDetailsResponse(room.Id, room.Name, room.CreatedAt, room.UpdatedAt);
    }
}
