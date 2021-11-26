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
    public class ValidFodselsnummeerTests
    {
        [Test, TestCaseSource(nameof(ValidPersonnummer))]
        public void Valid_Personnummer_ShouldReturnValid(string fodselsNummer)
        {
            var fnr = new Fodselsnummer(fodselsNummer);
            Assert.IsTrue(fnr.IsValid());
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
