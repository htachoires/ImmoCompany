using ImmoCompany.Banks;
using ImmoCompany.Domain;
using ImmoCompany.Emails;

namespace ImmoCompany.OfferOrchestrator;

public class OfferOrchestrator
{
    private readonly IBankService _bankService;
    private readonly IEmailService _emailService;

    public OfferOrchestrator(IBankService bankService, IEmailService emailService)
    {
        _bankService = bankService;
        _emailService = emailService;
    }

    public AcceptOfferResult AcceptOffer(Offer offer, Owner owner)
    {
        var result = _bankService.CompleteOffer(offer, owner);

        if (result.Status != CompleteOfferResult.TransactionStatus.InvalidCurrentBalance)
        {
            var cancelEmailToOwnerResult = _emailService.SendOfferCanceledToBuyer(offer);
            var cancelEmailToBuyerResult = _emailService.SendOfferCanceledToOwner(owner, offer);

            return new AcceptOfferResult
            {
                BankOfferResult = result,
                EmailResults = [cancelEmailToOwnerResult, cancelEmailToBuyerResult]
            };
        }

        var offerCompletedEmailToOwnerResult = _emailService.SendOfferCompletedToOldOwner(owner, offer);
        var offerCompletedEmailToBuyerResult = _emailService.SendOfferCompletedToNewOwner(offer);

        return new AcceptOfferResult
        {
            BankOfferResult = result,
            EmailResults = [offerCompletedEmailToOwnerResult, offerCompletedEmailToBuyerResult]
        };
    }
}