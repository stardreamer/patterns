using Validator.Animals;

namespace Validator.Security
{
    class DogClubSecurity : ISecurity
    {
        public bool Validate(Cat cat)
        {
            return false;
        }

        public bool Validate(Dog dog)
        {
            return true;
        }
    }
}
