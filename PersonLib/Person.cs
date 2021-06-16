using System;

namespace Smasgl.Model.PersonLib
{
    public class Person
    {
        private string lastName;
        private string firstname;

        public Person() { }

        public Person(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public string FirstName
        {
            get => this.firstname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception($"{nameof(Person)}:{nameof(FirstName)}");
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception($"{nameof(Person)}:{nameof(LastName)}");
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
