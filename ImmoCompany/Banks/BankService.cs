using ImmoCompany.Domain;

namespace ImmoCompany.Banks;

public class BankService : IBankService
{
    public CompleteOfferResult CompleteOffer(Offer offer, Owner owner)
    {
        if (offer.Buyer.CurrentBalance < offer.Amount)
        {
            return new CompleteOfferResult()
            {
                Status = CompleteOfferResult.TransactionStatus.InvalidCurrentBalance
            };
        }

        return new CompleteOfferResult()
        {
            Status = CompleteOfferResult.TransactionStatus.Completed,
            NewSellerBalance = owner.CurrentBalance + offer.Amount,
            NewBuyerBalance = offer.Buyer.CurrentBalance - offer.Amount
        };
    }
}