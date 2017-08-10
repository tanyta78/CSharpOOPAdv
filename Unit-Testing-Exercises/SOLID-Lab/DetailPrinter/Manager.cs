using System;
using System.Collections.Generic;
using System.Text;

namespace DetailPrinter
{
    public class Manager : Employee,IPrintable
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }
         
        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine(string.Join(Environment.NewLine, this.Documents));
            return sb.ToString().Trim();
        }
    }
}