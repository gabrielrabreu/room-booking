namespace RoomBooking.Rooms.Features.CreateRoom;

public record CreateRoomCommand(string Name) : ICommand<ErrorOr<RoomDetailsResponse>>;
