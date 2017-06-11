using System;
using System.Collections.Generic;
using System.Text;

namespace NameGenerator.Generators
{
    public class RussianNameGenerator : BaseNameGenerator
    {
        private readonly string[] _firstMaleNames = new string[] { "Антон", "Олег", "Роман", "Виктор" };
        private readonly string[] _firstFemaleNames = new string[] { "Виктория", "Светлана", "Катерина", "Ольга" };
        private readonly string[] _secondNames = new string[] { "Петров", "Семенов", "Иванов", "Борисов" };

        protected override string GenerateFirstName(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return _firstMaleNames[_random.Next(0, _firstMaleNames.Length)];
                case Gender.Female:
                    return _firstFemaleNames[_random.Next(0, _firstFemaleNames.Length)];
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        protected override string GenerateSurname(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return _secondNames[_random.Next(0, _secondNames.Length)];
                case Gender.Female:
                    return $"{_secondNames[_random.Next(0, _secondNames.Length)]}а";
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}
