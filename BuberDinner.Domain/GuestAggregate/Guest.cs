using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.valueObject;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace buberDinner.Domain.Guest;

public class Guest : AggregateRoot<GuestId>
{
    private readonly List<Guid> _upcomingDinnerIds = new();
    private readonly List<Guid> _pastDinnerIds = new();
    private readonly List<Guid> _pendingDinnerIds = new();
    private readonly List<Guid> _billIds = new();
    private readonly List<Guid> _menuReviewIds = new();
    private readonly List<GuestRating> _ratings = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }

    public IReadOnlyList<Guid> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<Guid> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<Guid> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<Guid> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<Guid> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    private Guest(
        GuestId guestid,
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestid)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest CreateUnique(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId
    )
    {
        return new Guest(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}