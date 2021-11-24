using System.Text.RegularExpressions;

namespace SSN
{
    public record Personnummer
    {
        public int? Day { get; private set; }
        public int? Month { get; private set; }
        public int? Year { get; private set; }
        public int? IndividualNumber { get; private set; }
        public int? CheckDigit { get; private set; }
        public Personnummer(string ssn)
        {
            Parse(ssn);
        }

        public bool IsValid()
        {
            if (!Regex.IsMatch(ToString(), "[0-9]{11}", RegexOptions.Singleline))
                return false;
            return true;
        }

        private void Parse(string ssn)
        {
            if (Regex.IsMatch(ssn, "[0-9]{11}",RegexOptions.Singleline))
            {
                if (int.TryParse(ssn.Substring(0, 2), out var day))
                    Day = day;
                if (int.TryParse(ssn.Substring(2, 2), out var month))
                    Month = month;
                if (int.TryParse(ssn.Substring(4, 2), out var year))
                    Year = year;
                if (int.TryParse(ssn.Substring(6, 3), out var individualNumber))
                    IndividualNumber = individualNumber;
                if (int.TryParse(ssn.Substring(9, 2), out var checkDigit))
                    CheckDigit = checkDigit;
            }
        }

        public override string ToString() => $"{Day?.ToString("D2")}{Month?.ToString("D2")}{Year?.ToString("D2")}{IndividualNumber?.ToString("D3")}{CheckDigit?.ToString("D2")}";
    }
}
