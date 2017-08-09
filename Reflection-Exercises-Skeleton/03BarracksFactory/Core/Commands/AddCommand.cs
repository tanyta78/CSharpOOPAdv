using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        private IRepository repository;

        private IUnitFactory unitFactory;

        public AddCommand(string[] data) : base(data)
        {
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
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