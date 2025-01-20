using ImmoCompany.Domain;
using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Tests.Unit.Tools;

public class OfferBuilder
{
    private BuildingBuilder _building = BuildingBuilder.ABuilding;
    private BuyerBuilder _buyer = BuyerBuilder.ABuyer;
    private Money _amount = Money.EUR(100);
    public static OfferBuilder AnOffer => new();

    private OfferBuilder()
    {
    }

    public Offer Build()
    {
        return new Offer
        {
            Building = _building.Build(),
            Buyer = _buyer.Build(),
            Amount = _amount
        };
    }

    public OfferBuilder WithAmount(Money amount)
    {
        _amount = amount;
        return this;
    }

    public OfferBuilder ForBuilding(BuildingBuilder building)
    {
        _building = building;
        return this;
    }

    public OfferBuilder By(BuyerBuilder buyer)
    {
        _buyer = buyer;
        return this;
    }
}