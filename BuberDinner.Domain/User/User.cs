using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User;

namespace BuberDinner.Domain.Entities;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string passWord,
        DateTime createdDateTime,
        DateTime updatedDateTime
        )
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = passWord;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User CreateUnique(
        string firstName,
        string lastName,
        string email,
        string passWord
        )
    {
        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            passWord,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

}