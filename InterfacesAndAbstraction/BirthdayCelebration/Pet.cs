public class Pet : IBirthable
{
    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; set; }
    public string Birthdate { get; set; }

    public bool CheckBirthdate(string checker)
    {
        if (this.Birthdate.EndsWith(checker))
        {
            return true;
        }
        return false;
    }
}