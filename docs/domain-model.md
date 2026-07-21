# Domain Model

## Users

```mermaid
classDiagram

class User {
    +Guid Id
    +string Email
    +string FullName
}

```

## Rooms

```mermaid
classDiagram

class Room {
    +Guid Id
    +string Name
    +int Capacity
    +bool IsActive
    +DateTime CreatedAt
    +DateTime LastModifiedAt

    +UpdateDetails(string name, int capacity)
    +Deactivate()
}
```

## Reservations

```mermaid
classDiagram

class Reservation {
    +Guid Id
    +Guid UserId
    +Guid RoomId
    +DateTime StartAt
    +DateTime EndAt
    +ReservationStatus Status
    +DateTime CreatedAt
    +DateTime LastModifiedAt
    +DateTime? ConfirmedAt

    +Confirm()
}

class ReservationStatus {
    <<enumeration>>
    Pending,
    Confirmed
}
```

## Reports

```mermaid
classDiagram

class FactReservation {
    +long ReservationFactKey

    +int DateKey
    +int RoomKey
    +int UserKey

    +Guid ReservationId

    +int DurationMinutes

    +DateTime IngestedAt
}

class DimDate {
    +int DateKey

    +DateTime Date

    +int Year
    +int Quarter
    +int Month
    +int Day

    +int DayOfWeek

    +string DayName
    +string MonthName
}

class DimRoom {
    +int RoomKey
    +Guid RoomId
    +string Name
    +int Capacity
    +DateTime FirstSeenAt
    +DateTime LastUpdatedAt
}

class DimUser {
    +int UserKey
    +Guid UserId
    +string FullName
    +string Email
    +DateTime FirstSeenAt
    +DateTime LastUpdatedAt
}

FactReservation --> DimDate
FactReservation --> DimRoom
FactReservation --> DimUser
```
