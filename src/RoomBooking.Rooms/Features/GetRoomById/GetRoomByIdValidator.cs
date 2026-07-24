namespace RoomBooking.Rooms.Features.GetRoomById;

public class GetRoomByIdValidator : AbstractValidator<GetRoomByIdQuery>
{
    public GetRoomByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
