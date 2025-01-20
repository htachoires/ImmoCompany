namespace ImmoCompany.Domain.Moneys;

public static class MoneyConverter
{
    public static Money ConvertMoneyToMatchDevise(this Money money, Devise target)
    {
        return target switch
        {
            Devise.USD => money.ToUSD(),
            Devise.RUB => money.ToRUB(),
            Devise.EUR => money.ToEUR(),
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
    }

    public static Money ToUSD(this Money money)
    {
        return money.Devise switch
        {
            Devise.USD => money,
            Devise.RUB => Money.RUB(money.Quantity * 1.1m),
            Devise.EUR => Money.USD(money.Quantity * 1.1m),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static Money ToRUB(this Money money)
    {
        return money.Devise switch
        {
            Devise.RUB => money,
            Devise.USD => Money.RUB(money.Quantity * 1.1m),
            Devise.EUR => Money.RUB(money.Quantity * 1.1m),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static Money ToEUR(this Money money)
    {
        return money.Devise switch
        {
            Devise.EUR => money,
            Devise.RUB => Money.EUR(money.Quantity * 1.1m),
            Devise.USD => Money.EUR(money.Quantity * 1.1m),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}