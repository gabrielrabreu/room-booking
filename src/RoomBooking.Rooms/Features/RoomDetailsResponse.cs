namespace RoomBooking.Rooms.Features;

public record RoomDetailsResponse(Guid Id, string Name, DateTimeOffset CreatedAt, DateTimeOffset? UpdatedAt);
