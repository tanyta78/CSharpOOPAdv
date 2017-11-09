using System;

public delegate void JobDoneEventHandler(object sender, JobEventArgs ea);

public class Job
{
    public event JobDoneEventHandler JobDone;

    public Job(string name, int workHoursRequered, BaseEmployee employee)
    {
        this.Name = name;
        this.WorkHoursRequered = workHoursRequered;
        this.Employee = employee;
        this.IsDone = false;
    }

    public bool IsDone { get; set; }
    public string Name { get; private set; }
    public int WorkHoursRequered { get; private set; }
    public BaseEmployee Employee { get; private set; }

    public void Update()
    {
        this.WorkHoursRequered -= Employee.WorkHoursPerWeek;

        if (this.WorkHoursRequered <= 0)
        {
            OnJobDone(new JobEventArgs(this));
        }
    }

    private void OnJobDone( JobEventArgs ea)
    {
        if (JobDone != null)
        {
            JobDone(this, ea);
        }
        Console.WriteLine($"Job {this.Name} done!");
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequered}";
    }
}