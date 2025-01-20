using ImmoCompany.Domain;
using ImmoCompany.Domain.Moneys;
using ImmoCompany.Emails;

namespace ImmoCompany.Banks;

public class BankService : IBankService
{
    private readonly IEmailService _emailService;

    public BankService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public CompleteOfferResult CompleteOffer(Offer offer, Owner owner)
    {
        //Student have to code the tests and implementation
        if (offer.Buyer.CurrentBalance <= offer.Amount)
        {
            return new CompleteOfferResult()
            {
                TransactionStatus = TransactionStatus.Canceled
            };
        }
        
        _emailService.SendEmail(owner, $"Congratulations! Your building located at {offer.Building.Address} has been sold for {offer.Amount} by {offer.Buyer.Name}");
        _emailService.SendEmail(offer.Buyer, $"Congratulations, your offer has been completed. You now own the building has been sold for {offer.Amount} by {offer.Buyer.Name}");

        return new CompleteOfferResult()
        {
            TransactionStatus = TransactionStatus.Completed,
            NewSellerBalance = owner.CurrentBalance + offer.Amount,
            NewBuyerBalance = offer.Buyer.CurrentBalance - offer.Amount
        };
    }
}

public record CompleteOfferResult
{
    public TransactionStatus TransactionStatus { get; init; }
    public Money NewSellerBalance { get; init; }
    public Money NewBuyerBalance { get; init; }
}

public enum TransactionStatus
{
    Pending,
    Completed,
    Canceled,
}