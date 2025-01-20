using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Domain;

public record Buyer : IPerson
{
    public string Name { get; init; }
    public Money CurrentBalance { get; init; }
}