using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery
{
    /// <summary>
    /// Class of person who is client and DeliveryMan
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// Name of persom
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last name of person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// id of person
        /// </summary>
        public Guid Id { get; set; }    

        /// <summary>
        /// date of birth of person
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// constructors of Person
        /// </summary>

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
        public Person()
        {

        }
    }
}
