using Validator.Animals;

namespace Validator.Security
{
    class CatClubSecurity : ISecurity
    {
        public bool Validate(Cat cat)
        {
            return true;
        }

        public bool Validate(Dog dog)
        {
            return false;
        }
    }
}
