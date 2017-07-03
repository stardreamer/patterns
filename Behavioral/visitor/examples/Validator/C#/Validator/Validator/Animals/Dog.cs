namespace Validator.Animals
{
    class Dog: Animal
    {
        public override bool Accept(ISecurity security)
        {
            return security.Validate(this);
        }
    }
}
