using ImmoCompany.Domain;

namespace ImmoCompany.Emails;

public interface IEmailService
{
    EmailResult SendEmail(IPerson person, string content);
}