namespace RoomBooking.Rooms.Features.ListRooms;

public record ListRoomsQuery : IQuery<ErrorOr<List<RoomSummaryResponse>>>;
