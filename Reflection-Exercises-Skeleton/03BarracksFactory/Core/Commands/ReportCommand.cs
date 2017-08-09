using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        private IRepository repository;

        public ReportCommand(string[] data) : base(data)
        {
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public override string Execute()
        {
            return this.Repository.Statistics;
        }
    }
}