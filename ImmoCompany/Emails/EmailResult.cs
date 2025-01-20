namespace ImmoCompany.Emails;

public record EmailResult
{
    public EmailStatus Status { get; init; }

    public enum EmailStatus
    {
        Success,
        Failed
    }
}