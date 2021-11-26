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
    public class GenerateTests
    {
        [Test, TestCaseSource(nameof(BirthDates))]
        public void GeneratedFodselsnummer_ShouldReturnValid(DateOnly birth)
        {
            var fnr = Fodselsnummer.Generate(birth);
            Assert.IsTrue(fnr.IsValid());
        }

        #region testdata
        static IEnumerable<DateOnly> BirthDates()
        {
            yield return new DateOnly(1854,12,1);
            yield return new DateOnly(1901, 8, 12);
            yield return new DateOnly(1940, 1, 1);
            yield return new DateOnly(1988, 6, 12);
            yield return new DateOnly(2001, 10, 23);
        }
        #endregion


    }
}
