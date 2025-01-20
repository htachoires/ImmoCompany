using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Domain;

public record Offer
{
    public Building Building { get; init; }
    public Buyer Buyer { get; init; }
    public Money Amount { get; init; }
}