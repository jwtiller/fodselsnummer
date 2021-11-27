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
            var ranges = new[] { (1885, 1887), (1940,1945), (1955,1960),(1971,1973),(1985,1990),(2000,2001),(2005,2007) };
            foreach (var range in ranges)
            {
                for (int year = range.Item1; year <= range.Item2; year++)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                        {
                            yield return new DateOnly(year, month, day);
                        }
                    }

                }
            }
        }
        #endregion


    }
}
