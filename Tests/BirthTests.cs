using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SSN;

namespace Tests
{
    [TestFixture]
    public class BirthTests
    {
        [Test]
        public void ShouldReturn_Year2008()
        {
            var ssn = new Personnummer("03080888626");
            Assert.AreEqual(DateOnly.Parse("03.08.2008"),ssn.Birth);
        }

        [Test]
        public void ShouldReturn_Year1909()
        {
            var ssn = new Personnummer("22100914445");
            Assert.AreEqual(DateOnly.Parse("22.10.1909"),ssn.Birth);
        }

        [Test]
        public void ShouldReturn_Year1881()
        {
            var ssn = new Personnummer("02077173385");
            Assert.AreEqual(DateOnly.Parse("02.07.1871"), ssn.Birth);
        }
    }
}
