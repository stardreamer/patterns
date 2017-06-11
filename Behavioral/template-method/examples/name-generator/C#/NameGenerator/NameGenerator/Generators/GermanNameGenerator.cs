using System;
using System.Collections.Generic;
using System.Text;

namespace NameGenerator.Generators
{
    public class GermanNameGenerator : BaseNameGenerator
    {
        private readonly string[] _firstMaleNames = new string[] { "Hans", "Heinz", "Horst", "Andreas" };
        private readonly string[] _firstFemaleNames = new string[] { "Anna", "Elke", "Birgit", "Stefanie" };
        private readonly string[] _secondNames = new string[] { "Müller", "Schröder", "Hartmann", "Schulze" };

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
