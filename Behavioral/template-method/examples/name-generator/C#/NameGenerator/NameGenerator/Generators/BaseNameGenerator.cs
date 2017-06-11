using System;
using System.Collections.Generic;
using System.Text;

namespace NameGenerator.Generators
{
    public enum Gender
    {
        Male,
        Female
    }

    public abstract class BaseNameGenerator
    {
        protected  Random _random = new Random();

        private Gender GetRandomGender()
        {
            switch(_random.Next(0, 2))
            {
                case 0:
                    return Gender.Male;
                case 1:
                    return Gender.Female;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected abstract string GenerateFirstName(Gender gender);

        protected abstract string GenerateSurname(Gender gender);

        public string GetName()
        {
            var gender = GetRandomGender();
            return $"{GenerateFirstName(gender)}  {GenerateSurname(gender)}";
        }
    }
}
