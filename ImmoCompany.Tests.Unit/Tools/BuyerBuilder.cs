using ImmoCompany.Domain;
using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Tests.Unit.Tools;

public class BuyerBuilder
{
    private string _name = "John Doe";
    private Money _currentBalance = Money.EUR(100);
    
    public static BuyerBuilder ABuyer => new();

    private BuyerBuilder()
    {
    }

    public Buyer Build()
    {
        return new Buyer
        {
            Name = _name,
            CurrentBalance = _currentBalance
        };
    }

    public BuyerBuilder WithCurrentBalance(Money currentBalance)
    {
        _currentBalance = currentBalance;
        return this;
    }
}