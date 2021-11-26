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
    public class ToStringTest
    {
        [Test, TestCaseSource(nameof(PersonnummerCases))]
        public void ToString_ShouldReturnSamePersonnummer(string fodselsNummer)
        {
            var fnr = new Fodselsnummer(fodselsNummer);
            Assert.AreEqual(fodselsNummer,fnr.ToString());
        }

        #region testdata

        static IEnumerable<string> PersonnummerCases()
        {
            yield return "27059226695";
            yield return "01059226695";
            yield return "01050226695";
            yield return "01050226605";
            yield return "01050220605";
        }

        #endregion

    }
}
