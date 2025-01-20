using ImmoCompany.Domain;

namespace ImmoCompany.Emails;

public interface IEmailService
{
    EmailResult SendOfferCompletedToNewOwner(Offer offer);
    EmailResult SendOfferCompletedToOldOwner(IPerson person, Offer offer);
    EmailResult SendOfferCanceledToOwner(IPerson person, Offer offer);
    EmailResult SendOfferCanceledToBuyer(Offer offer);
}