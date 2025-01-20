using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Domain;

public record Owner : IPerson
{
    public string Name { get; init; }
    public Money CurrentBalance { get; init; }
}