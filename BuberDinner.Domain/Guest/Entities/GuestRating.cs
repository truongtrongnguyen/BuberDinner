using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public float Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        GuestRatingId id,
        HostId hostId,
        float rating,
        DateTime createdDateTime,
        DateTime updatedDateTime
        )
        : base(id)
    {
        HostId = hostId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating CreateUnique(
        GuestRatingId id,
        HostId hostId,
        float rating
    )
    {
        return new GuestRating(
            GuestRatingId.CreateUnique(),

            hostId,
            rating,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}