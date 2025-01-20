using ImmoCompany.Banks;
using ImmoCompany.Emails;

namespace ImmoCompany.OfferOrchestrator;

public record AcceptOfferResult
{
    public CompleteOfferResult BankOfferResult { get; init; }
    public IEnumerable<EmailResult> EmailResults { get; init; }
}