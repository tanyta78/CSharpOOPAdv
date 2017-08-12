namespace EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs ea);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnNameChange(new NameChangeEventArgs(value));
            }
        }

        private void OnNameChange(NameChangeEventArgs ea)
        {
            if (NameChange != null)
            {
                NameChange(this, ea);
            }
        }
    }
}