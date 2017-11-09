using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace WorkForce
{
    public class StartUp
    {
        public static void Main()
        {
            JobsListHandler jobs = new JobsListHandler();
            List<BaseEmployee> employees = new List<BaseEmployee>();

            string[] input = Console.ReadLine().Split();

            while (input[0]!="End")
            {
                switch (input[0])
                {
                    case "Job":
                        var currentJob = new Job(input[1], int.Parse(input[2]),
                            employees.FirstOrDefault(e => e.Name == input[3]));
                        jobs.Add(currentJob);
                        currentJob.JobDone += jobs.OnJobDone;
                      
                        break;
                    case "StandartEmployee":
                        employees.Add(new StandartEmployee(input[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new ParttimeEmployee(input[1]));
                        break;
                    case "Pass":
                        if (jobs.Count!=0)
                        {
                            foreach (var job in jobs)
                            {
                                job.Update();
                            }

                            jobs.RemoveAll(j => j.IsDone == true);
                        }
                        break;
                    case "Status":
                        foreach (var job in jobs)
                        {
                            Console.WriteLine(job);
                            
                        }
                        break;
                }
                
                input = Console.ReadLine().Split();
            }
        }
    }
}