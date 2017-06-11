using System;
using System.Collections.Generic;
using System.Text;

namespace NameGenerator.Generators
{
    public class EnglishNameGenerator: BaseNameGenerator
    {
        private readonly string[] _firstMaleNames = new string[] { "Jim", "Richard", "Ted", "Robert", "Danny" };
        private readonly string[] _firstFemaleNames = new string[] { "Kate", "Susan", "Victoria", "Diana" };
        private readonly string[] _secondNames = new string[] { "Smith", "Black", "Robinson", "Rand" };

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
            return _secondNames[_random.Next(0, _secondNames.Length)];
        }
    }
}
