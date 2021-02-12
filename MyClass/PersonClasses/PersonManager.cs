using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingProject.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, Boolean isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                    ret = new Supervisor();
                else
                    ret = new Employee();

                ret.FirstName = first;
                ret.LastName  = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Rogerio", LastName = "Bento" });
            people.Add(new Person() { FirstName = "Laura", LastName = "Antonia" });
            people.Add(new Person() { FirstName = "Thiago", LastName = "Paulo" });

            return people;
        }
    }
}
