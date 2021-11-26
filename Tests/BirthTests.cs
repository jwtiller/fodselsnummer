using System;
using System.Collections.Generic;
using System.Globalization;
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
            Assert.AreEqual(DateOnly.ParseExact("03.08.2008", "dd.MM.yyyy", CultureInfo.InvariantCulture),ssn.Birth);
        }

        [Test]
        public void ShouldReturn_Year1909()
        {
            var ssn = new Personnummer("22100914445");
            Assert.AreEqual(DateOnly.ParseExact("22.10.1909","dd.MM.yyyy",CultureInfo.InvariantCulture),ssn.Birth);
        }

        [Test]
        public void ShouldReturn_Year1881()
        {
            var ssn = new Personnummer("02077173385");
            Assert.AreEqual(DateOnly.ParseExact("02.07.1871", "dd.MM.yyyy", CultureInfo.InvariantCulture), ssn.Birth);
        }
    }
}
