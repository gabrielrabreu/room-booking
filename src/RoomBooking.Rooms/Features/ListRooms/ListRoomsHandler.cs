using RoomBooking.Rooms.Data;

namespace RoomBooking.Rooms.Features.ListRooms;

public class ListRoomsHandler(RoomsDbContext dbContext) : IQueryHandler<ListRoomsQuery, ErrorOr<List<RoomSummaryResponse>>>
{
    public async ValueTask<ErrorOr<List<RoomSummaryResponse>>> Handle(ListRoomsQuery query, CancellationToken cancellationToken)
    {
        return await dbContext.Rooms
            .Select(r => new RoomSummaryResponse(r.Id, r.Name))
            .ToListAsync(cancellationToken);
    }
}
