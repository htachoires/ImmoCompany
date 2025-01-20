using ImmoCompany.Banks;
using ImmoCompany.Domain;
using ImmoCompany.Domain.Moneys;
using ImmoCompany.Emails;
using ImmoCompany.OfferOrchestrator;

var bankService = new BankService();
var emailService = new EmailService();

var offerOrchestrator = new OfferOrchestrator(bankService, emailService);

var buyer = new Buyer
{
    Name = "John Doe",
    CurrentBalance = Money.EUR(180_000)
};

var owner = new Owner
{
    Name = "Janie Doe",
    CurrentBalance = Money.EUR(15_000)
};

var building = new Building
{
    Address = "123 Main Street",
    Inhabitant = 1_093,
    Owner = owner
};

var offer = new Offer
{
    Building = building,
    Buyer = buyer,
    Amount = Money.EUR(150_000),
};

var result = offerOrchestrator.AcceptOffer(offer, owner);

Console.WriteLine("BankOfferResult: " + result.BankOfferResult);

foreach (var resultEmailResult in result.EmailResults)
{
    Console.WriteLine("EmailResult: " + resultEmailResult);
}