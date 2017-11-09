using System;
using System.Collections.Generic;

public class JobsListHandler : List<Job>
{
    public void OnJobDone(object sender, JobEventArgs ea)
    {
        ea.Job.IsDone = true;
    }
}
