using System.Collections;
using System.Collections.Generic;
using Fnr;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ParseTests
    {

        private readonly Fodselsnummer _fnr = new("01083626603");
        [Test]
        public void ShouldReturn_Correct_Day()
        {
            Assert.AreEqual(1,_fnr.Day);
        }

        [Test]
        public void ShouldReturn_Correct_Month()
        {
            Assert.AreEqual(8, _fnr.Month);
        }

        [Test]
        public void ShouldReturn_Correct_Year()
        {
            Assert.AreEqual(36, _fnr.Year);
        }


        [Test]
        public void ShouldReturn_Correct_IndividualNumber()
        {
            Assert.AreEqual(266, _fnr.IndividualNumber);
        }

        [Test]
        public void ShouldReturn_Correct_CheckDigit()
        {
            Assert.AreEqual(3, _fnr.CheckDigit);
        }

        [Test, TestCaseSource(nameof(PersonnummerWithInvalidCharacters))]
        public void InvalidCharacter_ShouldNotBeParsed(string fodselsNummer)
        {
            var fnr = new Fodselsnummer(fodselsNummer);
            Assert.IsNull(fnr.Day);
            Assert.IsNull(fnr.Month);
            Assert.IsNull(fnr.Year);
            Assert.IsNull(fnr.IndividualNumber);
            Assert.IsNull(fnr.CheckDigit);
        }


        #region testdata

        static IEnumerable<string> PersonnummerWithInvalidCharacters()
        {
            yield return "A1083626603";
            yield return "0108362660+";
            yield return "01083?26603";
        }

        #endregion


    }
}