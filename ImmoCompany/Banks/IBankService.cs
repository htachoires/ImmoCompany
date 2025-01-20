using ImmoCompany.Domain;

namespace ImmoCompany.Banks;

public interface IBankService
{
    CompleteOfferResult CompleteOffer(Offer offer, Owner owner);
}