using ImmoCompany.Domain;

namespace ImmoCompany.Emails;

public class EmailService : IEmailService
{
    public EmailResult SendOfferCanceledToOwner(IPerson person, Offer offer)
    {
        Console.WriteLine(
            $"To: {person.Name} Content: We try to complete one offer for you building located at {offer.Building.Address} but the offer was declined.");

        return new EmailResult
        {
            Status = EmailResult.EmailStatus.Success
        };
    }

    public EmailResult SendOfferCanceledToBuyer(Offer offer)
    {
        Console.WriteLine(
            $"To: {offer.Buyer.Name}. Content: Ouch! Your offer has been declined. Your balance does not permit to complete the order");

        return new EmailResult
        {
            Status = EmailResult.EmailStatus.Success
        };
    }

    public EmailResult SendOfferCompletedToNewOwner(Offer offer)
    {
        Console.WriteLine(
            $"To: {offer.Buyer.Name}. Content: Congratulations! Your offer for {offer.Building.Address} has been completed.");

        return new EmailResult
        {
            Status = EmailResult.EmailStatus.Success
        };
    }

    public EmailResult SendOfferCompletedToOldOwner(IPerson person, Offer offer)
    {
        Console.WriteLine(
            $"To: {person.Name}. Content: Congratulations! Your building located at {offer.Building.Address} has been sold for {offer.Amount} by {offer.Buyer.Name}");

        return new EmailResult
        {
            Status = EmailResult.EmailStatus.Success
        };
    }
}