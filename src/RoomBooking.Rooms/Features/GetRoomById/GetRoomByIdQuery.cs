namespace RoomBooking.Rooms.Features.GetRoomById;

public record GetRoomByIdQuery(Guid Id) : IQuery<ErrorOr<RoomDetailsResponse>>;
