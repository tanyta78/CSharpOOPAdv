public class ParttimeEmployee : BaseEmployee
{
    private const int WorkHoursPerWeek = 20;

    public ParttimeEmployee(string name) : base(name, WorkHoursPerWeek)
    {
    }
}