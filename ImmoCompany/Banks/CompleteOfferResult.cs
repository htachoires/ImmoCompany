using ImmoCompany.Domain.Moneys;

namespace ImmoCompany.Banks;

public record CompleteOfferResult
{
    public TransactionStatus Status { get; init; }
    public Money NewSellerBalance { get; init; }
    public Money NewBuyerBalance { get; init; }


    public enum TransactionStatus
    {
        InvalidCurrentBalance,
        Completed,
    }
}