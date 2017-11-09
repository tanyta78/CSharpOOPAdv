namespace DetailPrinter
{
    public class Employee:IPrintable
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string Print()
        {
            return this.Name;
        }
    }
}