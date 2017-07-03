using Validator.Animals;

namespace Validator
{
    interface ISecurity
    {
        bool Validate(Cat cat);
        bool Validate(Dog dog);
    }
}
