using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        
        public AddCommand(string[] data,IRepository repository,IUnitFactory unitFactory) : base(data,repository,unitFactory)
        {
        }

        
        public override string Execute()
        {
            string unitType = this.Data[0];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);

            return $"{unitType} added!";
        }
    }
}