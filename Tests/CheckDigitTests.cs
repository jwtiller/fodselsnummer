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
    public class CheckDigitTests
    {
        [Test]
        public void ValidFodselsNummer_ShouldReturn_Valid()
        {
            var fnr = new Fodselsnummer("29105114492");
            Assert.IsTrue(fnr.IsCheckDigitValid());
        }

        [Test]
        public void AlteredFodselsNummer_ShouldReturn_Invalid()
        {
            var fnr = new Fodselsnummer("19105114492");
            Assert.IsFalse(fnr.IsCheckDigitValid());
        }
    }
}
