using System;
using System.Collections.Generic;
using System.Text;
using CSharp7Samples.Helpers;

namespace CSharp7Samples.Models
{
    public class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public Person(string name) =>
            name.Split(' ').MoveElementsTo(out _firstName, out _lastName);


        public string FirstName => _firstName;
        public string LastName => _lastName;
    }
}
