using DependenceInjection.Attributes;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[0];

            this.repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }

        
    }
}