namespace SOLID.Core.Commands
{
    using SOLID.Contracts.Core;
    using SOLID.Contracts.Data;

    public abstract class Command: IExecutable
    {
        //в същата папка създаваме различни команди. Създавам една за пример AddCommand
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public string[] Data { get => this.data; set => this.data = value; }

        public IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        public IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            set { this.unitFactory = value; }
        }

        
        public abstract string Execute();
       
    }
}
