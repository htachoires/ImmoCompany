using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Domain;

public interface IPerson
{
    string Name { get; init; }
    Money CurrentBalance { get; init; }
}