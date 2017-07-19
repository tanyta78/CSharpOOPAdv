public interface IBirthable
{
    string Birthdate { get; set; }

    bool CheckBirthdate(string checker);
}