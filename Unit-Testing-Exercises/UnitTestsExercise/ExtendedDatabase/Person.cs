using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDatabase
{
   public class Person
   {
       private long id;
       private string userName;

        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public long Id { get; private set; }
        public string UserName { get; private set; }

       public override bool Equals(object obj)
       {
           Person other = obj as Person;
           if (other == null)
           {
               return false;
           }

           if (this.Id == other.Id && this.UserName == other.UserName)
           {
               return true;
           }

           return false;
       }

       public override int GetHashCode()
       {
           return this.Id.GetHashCode() ^ this.UserName.GetHashCode() ^ 23;
       }
    }
}
