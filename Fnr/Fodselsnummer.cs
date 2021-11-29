using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Fnr
{
    public record Fodselsnummer
    {
        public int? Day { get; private set; }
        public int? Month { get; private set; }
        public int? Year { get; private set; }
        public int? IndividualNumber { get; private set; }
        public int? CheckDigit { get; private set; }
        public Gender Gender { get; private set; }
        public DateOnly Birth => GetBirth();

        private readonly string _fodselsnummer;
        public Fodselsnummer(string fodselsnummer)
        {
            _fodselsnummer = fodselsnummer;
            Parse(fodselsnummer);
        }

        public bool IsValid()
        {
            if (!Regex.IsMatch(_fodselsnummer, "[0-9]{11}", RegexOptions.Singleline))
                return false;
            if (!IsCheckDigitValid())
                return false;
            return true;
        }

        public bool IsCheckDigitValid()
        {
            var expected = CalculateCheckDigit($"{Day:D2}{Month:D2}{Year}{IndividualNumber:D3}");
            if (CheckDigit != expected)
            {
            }
            return CheckDigit == expected;
        }

        private static int CalculateCheckDigit(string fnrAndIndividualNumber)
        {
            var c1 = 11 - ((3 * Convert.ToInt32(fnrAndIndividualNumber.Substring(0,1)) + 7 * Convert.ToInt32(fnrAndIndividualNumber.Substring(1, 1)) + 6 * Convert.ToInt32(fnrAndIndividualNumber.Substring(2, 1)) + 1 * Convert.ToInt32(fnrAndIndividualNumber.Substring(3, 1)) + 8 * Convert.ToInt32(fnrAndIndividualNumber.Substring(4, 1)) + 9 * Convert.ToInt32(fnrAndIndividualNumber.Substring(5, 1)) + 4 * Convert.ToInt32(fnrAndIndividualNumber.Substring(6, 1)) + 5 * Convert.ToInt32(fnrAndIndividualNumber.Substring(7, 1)) + 2 * Convert.ToInt32(fnrAndIndividualNumber.Substring(8, 1))) % 11);
            var c2 = 11 - ((5 * Convert.ToInt32(fnrAndIndividualNumber.Substring(0, 1)) + 4 * Convert.ToInt32(fnrAndIndividualNumber.Substring(1, 1)) + 3 * Convert.ToInt32(fnrAndIndividualNumber.Substring(2, 1)) + 2 * Convert.ToInt32(fnrAndIndividualNumber.Substring(3, 1)) + 7 * Convert.ToInt32(fnrAndIndividualNumber.Substring(4, 1)) + 6 * Convert.ToInt32(fnrAndIndividualNumber.Substring(5, 1)) + 5 * Convert.ToInt32(fnrAndIndividualNumber.Substring(6, 1)) + 4 * Convert.ToInt32(fnrAndIndividualNumber.Substring(7, 1)) + 3 * Convert.ToInt32(fnrAndIndividualNumber.Substring(8, 1)) + 2 * c1) % 11);

            if (c1 == 11) // special rule
                c1 = 0;
            if (c2 == 11)
                c2 = 0;

            int.TryParse($"{c1}{c2}", out int expected);
            return expected;
        }

        private DateOnly GetBirth()
        {
            var yearHundred = _induvidualNumberYearhundredMapping.FirstOrDefault(x => IndividualNumber >= x.lower && IndividualNumber < x.upper).yearHundred;
            return DateOnly.ParseExact($"{Day?.ToString("D2")}.{Month?.ToString("D2")}.{yearHundred}{Year?.ToString("D2")}", "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        public static Fodselsnummer Generate(DateOnly birth, Gender gender = Gender.Undefined)
        {
            var individualNumberRange =
                _induvidualNumberYearhundredMapping.FirstOrDefault(x =>
                    x.yearStart <= birth.Year && birth.Year <= x.yearEnd);
            int individualNumber = 0;
            int checkDigit = 0;
            while (checkDigit.Length() != 2) // if generates check digit length of 3 in odd cases
            {
                individualNumber = RandomNumber(individualNumberRange.lower, individualNumberRange.upper, gender);
                checkDigit =
                    CalculateCheckDigit(
                        $"{birth.Day:D2}{birth.Month:D2}{birth.Year.ToString().Substring(0, 2)}{individualNumber:D3}");
            }

            return new Fodselsnummer($"{birth.Day:D2}{birth.Month:D2}{birth.Year.ToString().Substring(0,2)}{individualNumber:D3}{checkDigit:D2}");
        }

        private static int RandomNumber(int from, int to, Gender gender)
        {
            int rnd = RandomNumberGenerator.GetInt32(from, to);
            if (gender == Gender.Undefined)
                return rnd;
            bool even = rnd.Split().Last() % 2 == 0;
            while ((even && gender == Gender.Male) || (!even && gender == Gender.Female))
            {
                rnd = RandomNumberGenerator.GetInt32(from, to);
                even = rnd.Split().Last() % 2 == 0;
            }

            return rnd;
        }

        private static readonly List<(int yearHundred, int yearStart, int yearEnd, int lower, int upper)> _induvidualNumberYearhundredMapping = new()
        {
            (19,1900,1999, 0, 500),
            (18, 1854,1899, 500, 750),
            (19, 1940,1999, 900, 1000), 
            (20, 2000,2039,500, 1000)
        };


        private void Parse(string fodselsNummer)
        {
            if (Regex.IsMatch(fodselsNummer, "[0-9]{11}",RegexOptions.Singleline))
            {
                if (int.TryParse(fodselsNummer.Substring(0, 2), out var day))
                    Day = day;
                if (int.TryParse(fodselsNummer.Substring(2, 2), out var month))
                    Month = month;
                if (int.TryParse(fodselsNummer.Substring(4, 2), out var year))
                    Year = year;
                if (int.TryParse(fodselsNummer.Substring(6, 3), out var individualNumber))
                    IndividualNumber = individualNumber;
                if (int.TryParse(fodselsNummer.Substring(9, 2), out var checkDigit))
                    CheckDigit = checkDigit;

                if (int.TryParse(fodselsNummer.Substring(8, 1), out var genderDigit))
                    Gender = genderDigit % 2 == 0 ? Gender.Female : Gender.Male;

            }
        }

        public override string ToString() => $"{Day?.ToString("D2")}{Month?.ToString("D2")}{Year?.ToString("D2")}{IndividualNumber?.ToString("D3")}{CheckDigit?.ToString("D2")}";
    }
}
