using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fnr;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GenderTests
    {
        [Test]
        public void OddDigit_Should_Return_Male()
        {
            var fnr = new Fodselsnummer("03083626762");
            Assert.AreEqual(Gender.Male,fnr.Gender);
        }

        [Test]
        public void EvenDigit_Should_Return_Female()
        {
            var fnr = new Fodselsnummer("08065838215");
            Assert.AreEqual(Gender.Female, fnr.Gender);
        }
    }
}
