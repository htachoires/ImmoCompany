using ImmoCompany.Domain;
using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Tests.Unit.Tools;

public class OwnerBuilder
{
    private string _name = "John Doe";
    private Money _currentBalance = Money.EUR(100);

    public static OwnerBuilder AnOwner => new();

    private OwnerBuilder()
    {
    }

    public Owner Build()
    {
        return new Owner
        {
            Name = _name,
            CurrentBalance = _currentBalance
        };
    }

    public OwnerBuilder WithCurrentBalance(Money currentBalance)
    {
        _currentBalance = currentBalance;
        return this;
    }

    public OwnerBuilder Owning(BuildingBuilder building)
    {
        return this;
    }
}