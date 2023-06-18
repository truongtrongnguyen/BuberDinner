
namespace BuberDinner.Domain.DinnerAggregate.valueObjects;

public class Price
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;

    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}