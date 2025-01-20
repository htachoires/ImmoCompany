using ImmoCompany.Banks;
using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Tests.Unit.Banks;

public class BankTests
{
    [Fact]
    public void Complete_Offer_with_current_balance_greater_than_amount_offer_should_credit_the_seller()
    {
        //Arrange
        var offerAmount = Money.EUR(150_000);
        var buyerAmount = Money.EUR(180_000);

        var owner = AnOwner.WithCurrentBalance(Money.EUR(0));

        var offer = AnOffer
            .WithAmount(offerAmount)
            .ForBuilding(ABuilding.OwnedBy(owner))
            .By(ABuyer.WithCurrentBalance(buyerAmount))
            .Build();

        var sut = new BankService(); //sut => system under test

        //Act
        var completeOfferResult = sut.CompleteOffer(offer, owner.Build());

        //Assert
        Assert.Equal(CompleteOfferResult.TransactionStatus.Completed, completeOfferResult.Status);
        Assert.Equal(150_000, completeOfferResult.NewSellerBalance.Quantity);
    }

    [Fact(Skip = "Not implemented yet")]
    public void Complete_Offer_with_current_balance_equals_amount_offer_should_credit_the_seller()
    {
        //Arrange
        var offerAmount = Money.EUR(180_000);
        var buyerAmount = Money.EUR(180_000);

        //TODO: implement arrange part to setup desire behavior

        var sut = new BankService(); //sut => system under test

        //Act
        var completeOfferResult = sut.CompleteOffer(null, null); //TODO: replace null with setup

        //Assert
        Assert.Equal(CompleteOfferResult.TransactionStatus.Completed, completeOfferResult.Status);
        Assert.Equal(150_000, completeOfferResult.NewSellerBalance.Quantity);
    }

    [Fact(Skip = "Not implemented yet")]
    public void Complete_Offer_with_current_balance_lower_than_amount_offer_should_refuse_the_offer()
    {
        //Arrange
        var offerAmount = Money.EUR(180_000);
        var buyerAmount = Money.EUR(150_000);
        //TODO: implement arrange part to setup desire behavior

        var sut = new BankService(); //sut => system under test

        //Act
        var completeOfferResult = sut.CompleteOffer(null, null); //TODO: replace null with setup

        //Assert
        Assert.Equal(CompleteOfferResult.TransactionStatus.Completed, completeOfferResult.Status);
        Assert.Equal(150_000, completeOfferResult.NewSellerBalance.Quantity);
    }
}