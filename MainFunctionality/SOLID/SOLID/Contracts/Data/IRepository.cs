namespace SOLID.Contracts.Data
{
    using SOLID.Contracts.Entities;

    public interface IRepository
    {
        string Statistics { get; }
        void AddUnit(IUnit unit);
        void RemoveUnit(string unitType);
    }
}
