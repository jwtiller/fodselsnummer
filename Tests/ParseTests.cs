using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SSN;

namespace Tests
{
    [TestFixture]
    public class ParseTests
    {

        private readonly Personnummer _ssn = new("01083626603");
        [Test]
        public void ShouldReturn_Correct_Day()
        {
            Assert.AreEqual(1,_ssn.Day);
        }

        [Test]
        public void ShouldReturn_Correct_Month()
        {
            Assert.AreEqual(8, _ssn.Month);
        }

        [Test]
        public void ShouldReturn_Correct_Year()
        {
            Assert.AreEqual(36, _ssn.Year);
        }


        [Test]
        public void ShouldReturn_Correct_IndividualNumber()
        {
            Assert.AreEqual(266, _ssn.IndividualNumber);
        }

        [Test]
        public void ShouldReturn_Correct_CheckDigit()
        {
            Assert.AreEqual(3, _ssn.CheckDigit);
        }

        [Test, TestCaseSource(nameof(PersonnummerWithInvalidCharacters))]
        public void InvalidCharacter_ShouldNotBeParsed(string personNummer)
        {
            var ssn = new Personnummer(personNummer);
            Assert.IsNull(ssn.Day);
            Assert.IsNull(ssn.Month);
            Assert.IsNull(ssn.Year);
            Assert.IsNull(ssn.IndividualNumber);
            Assert.IsNull(ssn.CheckDigit);
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