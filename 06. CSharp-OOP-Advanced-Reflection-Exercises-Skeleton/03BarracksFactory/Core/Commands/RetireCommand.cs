using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public override string Execute()
        {
            string unitType = this.Data[0];

            this.Repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}