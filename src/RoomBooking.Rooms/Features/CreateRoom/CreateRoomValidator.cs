namespace RoomBooking.Rooms.Features.CreateRoom;

public class CreateRoomValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}
