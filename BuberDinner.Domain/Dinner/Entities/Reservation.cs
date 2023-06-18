using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.valueObject;

namespace BuberDinner.Domain.Dinner.Entities;

public class Reservation : Entity<ReservationId>
{
    private Reservation(
        ReservationId id,
        int guestCount,
        string reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public int GuestCount { get; }
    public string ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public static Reservation CreateUnique(
        int guestCount,
        string reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime
    )
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}