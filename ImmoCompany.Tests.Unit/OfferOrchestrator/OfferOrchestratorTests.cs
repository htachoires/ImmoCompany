using ImmoCompany.Banks;
using ImmoCompany.Domain;
using ImmoCompany.Domain.Moneys;
using ImmoCompany.Emails;

namespace ImmoCompany.Tests.Unit.OfferOrchestrator;

public class OfferOrchestratorTests
{
    [Fact]
    public void AcceptOffer_with_valid_offer_should_return_completed_offer_status()
    {
        //Arrange
        var bankService = Substitute.For<IBankService>();

        bankService
            .CompleteOffer(Arg.Any<Offer>(), Arg.Any<Owner>())
            .Returns(new CompleteOfferResult
            {
                Status = CompleteOfferResult.TransactionStatus.Completed,
            });

        var emailService = Substitute.For<IEmailService>();

        var sut = new ImmoCompany.OfferOrchestrator.OfferOrchestrator(bankService, emailService);

        var offer = new Offer
        {
            Building = ABuilding.Build(),
            Buyer = ABuyer.Build(),
            Amount = Money.EUR(10_000)
        };

        //Act
        var completeOfferResult = sut.AcceptOffer(offer, AnOwner.Build());

        //Assert
        Assert.Equal(CompleteOfferResult.TransactionStatus.Completed, completeOfferResult.BankOfferResult.Status);
    }

    [Fact(Skip = "Not implemented yet")]
    public void AcceptOffer_with_valid_offer_should_send_success_email_to_buyer()
    {
        //Arrange
        //TODO

        //Act
        //TODO

        //Assert
        //TODO
    }

    [Fact(Skip = "Not implemented yet")]
    public void AcceptOffer_with_valid_offer_should_send_success_email_to_seller()
    {
        //Arrange
        //TODO

        //Act
        //TODO

        //Assert
        //TODO
    }

    [Fact(Skip = "Not implemented yet")]
    public void AcceptOffer_with_invalid_offer_should_send_cancel_email_to_owner()
    {
        //Arrange
        //TODO

        //Act
        //TODO

        //Assert
        //TODO
    }

    [Fact(Skip = "Not implemented yet")]
    public void AcceptOffer_with_invalid_offer_should_send_cancel_email_to_buyer()
    {
        //Arrange
        //TODO

        //Act
        //TODO

        //Assert
        //TODO
    }
}