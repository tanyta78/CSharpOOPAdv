using System;
using System.Collections.Generic;

namespace DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IPrintable> employees;

        public DetailsPrinter(IList<IPrintable> employees)
        {
            this.employees = employees;
        }

        public void printDetails()
        {
            foreach (IPrintable employee in this.employees)
            {
                Console.WriteLine(employee.Print());
            }
        }
    }
}