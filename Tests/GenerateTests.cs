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
            yield return new DateOnly(1863, 5, 17);
            yield return new DateOnly(1901, 8, 12);
            yield return new DateOnly(1910, 3, 29);
            yield return new DateOnly(1940, 1, 1);
            yield return new DateOnly(1952, 11, 3);
            yield return new DateOnly(1977, 4, 22);
            yield return new DateOnly(1988, 6, 12);
            yield return new DateOnly(2001, 10, 23);
            yield return new DateOnly(2005, 7, 27);
            yield return new DateOnly(2015, 10, 5);
        }
        #endregion


    }
}
