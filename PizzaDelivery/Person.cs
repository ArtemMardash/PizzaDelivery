using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    internal class Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public Guid Id { get; set; }    

        public DateTime BirthDate { get; set; }

        public Person()
        {

        }

        public Person(string name, string lastName, Guid id, DateTime birthDate)
        {
            Name = name;
            LastName = lastName;
            Id = id;
            BirthDate = birthDate;
        }

        public Person(string name, string lastName, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}
