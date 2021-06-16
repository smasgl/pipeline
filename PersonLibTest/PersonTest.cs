using Smasgl.Model.PersonLib;
using System;
using System.Collections.Generic;
using Xunit;

namespace PersonLibTest
{
    public class PersonTest
    {
        public static IEnumerable<object[]> Get_Constructor_Data_Passing()
        {
            yield return new object[] { "Simon", "Masooglu", true };
            yield return new object[] { "Simon", "Masooglu", false };
        }

        [Theory]
        [MemberData(nameof(Get_Constructor_Data_Passing))]
        public void Person_Constructor_Passing(string firstName, string lastName, bool constructor)
        {
            Person person;

            if (constructor)
                person = new(firstName, lastName);
            else
                person = new(){ FirstName = firstName, LastName = lastName};



            Assert.NotNull(person);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);

            Assert.Equal($"{firstName} {lastName}", person.ToString());
        }

        public static IEnumerable<object[]> Get_Constructor_Data_Failing()
        {
            yield return new object[] { "Simon", string.Empty, true};
            yield return new object[] { string.Empty, "Masooglu", true };
            yield return new object[] { string.Empty, string.Empty, true };
            yield return new object[] { "Simon", null, true };
            yield return new object[] { null, "Masooglu", true };
            yield return new object[] { null, null, true };
            yield return new object[] { string.Empty, null, true };
            yield return new object[] { null, string.Empty, true };
            yield return new object[] { "Simon", string.Empty, false };
            yield return new object[] { string.Empty, "Masooglu", false };
            yield return new object[] { string.Empty, string.Empty, false };
            yield return new object[] { "Simon", null, false };
            yield return new object[] { null, "Masooglu", false };
            yield return new object[] { null, null, false };
            yield return new object[] { string.Empty, null, false };
            yield return new object[] { null, string.Empty, false };
        }

        [Theory]
        [MemberData(nameof(Get_Constructor_Data_Failing))]
        public void Person_Constructor_Failing(string firstName, string lastName, bool constructor)
        {
            Person person = null;

            if (constructor)
                Assert.Throws<Exception>(() => person = new(firstName, lastName));
            else
                Assert.Throws<Exception>(() => person = new() { FirstName = firstName, LastName = lastName });

            Assert.Null(person);
        }
    }
}
