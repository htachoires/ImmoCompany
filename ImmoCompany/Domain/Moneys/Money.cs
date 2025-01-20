namespace ImmoCompany.Domain.Moneys;

public class Money
{
    public decimal Quantity { get; init; }
    public Devise Devise { get; init; }

    public static Money USD(decimal quantity)
    {
        return new Money { Quantity = quantity, Devise = Devise.USD };
    }
    
    public static Money RUB(decimal quantity)
    {
        return new Money { Quantity = quantity, Devise = Devise.USD };
    }

    public static Money EUR(decimal quantity)
    {
        return new Money { Quantity = quantity, Devise = Devise.EUR };
    }

    public static bool operator ==(Money obj1, Money obj2)
    {
        return obj1.Quantity == obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity;
    }

    public static Money operator +(Money obj1, Money obj2)
    {
        return new Money() { Quantity = obj1.Quantity + obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity };
    }

    public static Money operator -(Money obj1, Money obj2)
    {
        return new Money() { Quantity = obj1.Quantity - obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity };
    }

    public static Money operator /(Money obj1, Money obj2)
    {
        return new Money() { Quantity = obj1.Quantity / obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity };
    }

    public static bool operator >=(Money obj1, Money obj2)
    {
        return obj1.Quantity >= obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity;
    }

    public static bool operator <=(Money obj1, Money obj2)
    {
        return obj1.Quantity <= obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity;
    }

    public static bool operator <(Money obj1, Money obj2)
    {
        return obj1.Quantity < obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity;
    }

    public static bool operator >(Money obj1, Money obj2)
    {
        return obj1.Quantity > obj2.ConvertMoneyToMatchDevise(obj1.Devise).Quantity;
    }

    public static bool operator !=(Money obj1, Money obj2)
    {
        return !(obj1 == obj2.ConvertMoneyToMatchDevise(obj1.Devise));
    }
}