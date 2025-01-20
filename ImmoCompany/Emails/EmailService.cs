using ImmoCompany.Domain;

namespace ImmoCompany.Emails;

public class EmailService : IEmailService
{
    public EmailResult SendEmail(IPerson person, string content)
    {
        
        
        return new EmailResult
        {
            Status = EmailStatus.Success
        };
    }
}

public enum EmailStatus
{
    Success,
    Failed
}