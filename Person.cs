using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamDataGrid.Zoomable
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }

        public Person(string firstName, string lastName, string occupation)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Occupation = occupation;
        }

        public static List<Person> CreatePersons()
        {
            return new List<Person>() { new Person("Jim", "Dangle", "Lieutenant"),
                                        new Person("James ", "Garcia", "Deputy Sergeant Class III"),
                                        new Person("Sven", "Jones", "Deputy Sergeant Class II"),  
                                        new Person("Clementine", "Johnson", "Deputy Sergeant Class I"),
                                        new Person("Travis", "Junior", "Deputy"),
                                        new Person("Raineesha", "Williams", "Deputy"), 
                                        new Person("Cherisha", "Kimball", "Deputy") };
        }
    }
}
