namespace RoomBooking.Rooms.Models;

public class Room
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }

    public Room(string name)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    private Room()
    {
    }
}
