using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTestingProject.PersonClasses;

namespace UnitTestingProjectTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("Rogerio Bento")]
        public void AreCollectionEqualWithCompareTest()
        {
            PersonManager perMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Rogerio", LastName = "Bento" });
            peopleExpected.Add(new Person() { FirstName = "Laura", LastName = "Antonia" });
            peopleExpected.Add(new Person() { FirstName = "Thiago", LastName = "Paulo" });

            peopleActual = perMgr.GetPeople();

            CollectionAssert.AreEqual(peopleActual, peopleExpected, 
                Comparer<Person>.Create((x,y) => 
                    x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }
    }
}
