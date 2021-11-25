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
    public class CheckDigitTests
    {
        [Test]
        public void ValidFodselsNummer_ShouldReturn_Valid()
        {
            var ssn = new Personnummer("29105114492");
            Assert.IsTrue(ssn.IsCheckDigitValid());
        }

        [Test]
        public void AlteredFodselsNummer_ShouldReturn_Invalid()
        {
            var ssn = new Personnummer("19105114492");
            Assert.IsFalse(ssn.IsCheckDigitValid());
        }
    }
}
