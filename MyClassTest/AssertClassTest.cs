using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingProject.PersonClasses;

namespace UnitTestingProjectTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreSame / AreNotSame
        [TestMethod]
        public void AreSame()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }
        
        [TestMethod]
        public void AreNotSame()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion

        #region  IsInstanceOfType Test

        [TestMethod]
        [Owner("Rogerio Bento")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mg = new PersonManager();
            Person per;

            per = mg.CreatePerson("Rogerio", "Bento", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Rogerio Bento")]
        public void IsNullTest()
        {
            PersonManager mg = new PersonManager();
            Person per;

            per = mg.CreatePerson("", "Bento", true);

            Assert.IsNull(per);
        }
        #endregion

    }
}
