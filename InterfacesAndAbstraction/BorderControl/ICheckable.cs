public interface ICheckable
{
    string Id { get; }

    bool CheckId(string checker);
}