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
    public class GenderTests
    {
        [Test]
        public void OddDigit_Should_Return_Male()
        {
            var ssn = new Personnummer("03083626762");
            Assert.AreEqual(Gender.Male,ssn.Gender);
        }

        [Test]
        public void EvenDigit_Should_Return_Female()
        {
            var ssn = new Personnummer("08065838215");
            Assert.AreEqual(Gender.Female, ssn.Gender);
        }
    }
}
