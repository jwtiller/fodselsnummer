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
    public class ValidPersonnummerTests
    {
        [Test, TestCaseSource(nameof(ValidPersonnummer))]
        public void Valid_Personnummer_ShouldReturnValid(string personNummer)
        {
            var ssn = new Personnummer(personNummer);
            Assert.IsTrue(ssn.IsValid());
        }

        #region testdata

        static IEnumerable<string> ValidPersonnummer()
        {
            yield return "03054510380";
            yield return "13064227259";
            yield return "10029117077";
            yield return "05026409502";
            yield return "10059430985";
            yield return "26119429209";
        }

        #endregion

    }
}
