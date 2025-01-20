namespace ImmoCompany.Domain;

public record Building
{
    public string Address { get; init; }
    public int Inhabitant { get; init; }
    public Owner Owner { get; init; }
}