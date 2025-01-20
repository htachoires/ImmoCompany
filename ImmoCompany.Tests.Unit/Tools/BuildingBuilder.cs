using ImmoCompany.Domain;

namespace ImmoCompany.Tests.Unit.Tools;

public class BuildingBuilder
{
    private string _address = "123 Main Street";
    private int _inhabitant = 30;
    private OwnerBuilder _owner = AnOwner;
    public static BuildingBuilder ABuilding => new();

    private BuildingBuilder()
    {
    }

    public Building Build()
    {
        return new Building
        {
            Address = _address,
            Inhabitant = _inhabitant,
            Owner = _owner.Build(),
        };
    }

    public BuildingBuilder OwnedBy(OwnerBuilder owner)
    {
        _owner = owner;
        return this;
    }
}