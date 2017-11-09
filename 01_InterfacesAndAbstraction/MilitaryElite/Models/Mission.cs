using System.Text;

public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        State = state;
    }

    public string CodeName { get; }
    public string State { get; set; }

    public void CompleteMission()
    {
        this.State = "Finished";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"  Code Name: {CodeName} State: {State}");

        return sb.ToString().Trim();
    }
}