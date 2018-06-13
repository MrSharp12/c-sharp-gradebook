using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "danzig";
            name = name.ToUpper();

            Assert.AreEqual("DANZIG", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2018, 6, 12);
            date = date.AddDays(1);

            Assert.AreEqual(13, date.Day);
        }

        //[TestMethod]
        //public void ValueTypesPassByValue()
        //{
        //    int x = 46;
        //    incrementNumber(out x);

        //    Assert.AreEqual(47, x);
        //}
        ////with out, the c# compiler assumes you are making an output through the parameter
        //private void incrementNumber(out int number)
        //{
        //    number += 1;
        //}

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(ref book2);
            Assert.AreEqual("A Gradebook.", book2.Name);
        }

        private void GiveBookAName(ref GradeBook book)//ref is receving a reference from the calling code
        {
            book = new GradeBook();
            book.Name = "A Gradebook.";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Danzig";
            string name2 = "danzig";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;


            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Danzig's gradebook.";
            Assert.AreNotEqual(g1.Name, g2.Name);
            
        }

    }
}
