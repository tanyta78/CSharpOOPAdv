public class Robot : ICheckable
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; set; }
    public string Id { get; }

    public bool CheckId(string checker)
    {
        if (this.Id.EndsWith(checker))
        {
            return false;
        }
        return true;
    }
}