using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        [Test, TestCaseSource(nameof(BirthDates))]
        public void GeneratedFodselsnummer_ShouldOnlyReturn_Male(DateOnly birth)
        {
            var fnr = Fodselsnummer.Generate(birth, Gender.Male);
            Assert.AreEqual(Gender.Male, fnr.Gender);
        }

        [Test, TestCaseSource(nameof(BirthDates))]
        public void GeneratedFodselsnummer_ShouldOnlyReturn_Female(DateOnly birth)
        {
            var fnr = Fodselsnummer.Generate(birth, Gender.Female);
            Assert.AreEqual(Gender.Female, fnr.Gender);
        }

        #region testdata
        static IEnumerable<DateOnly> BirthDates()
        {
            var items = new List<DateOnly>();
            for (int year = 1884; year <= DateTime.Now.Year; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                    {
                        items.Add(new DateOnly(year, month, day));
                    }
                }

            }
            Shuffle(items);
            return items.Take(500);
        }
        #endregion


        public static void Shuffle<T>(IList<T> list)
        {
            for (int n = list.Count-1; n > 1; n--)
            {
                int k = RandomNumberGenerator.GetInt32(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

    }
}
