namespace SOLID.Contracts.Core
{
    using SOLID.Contracts.Entities;

    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
