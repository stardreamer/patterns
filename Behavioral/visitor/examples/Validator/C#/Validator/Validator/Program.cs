using System;
using Validator.Animals;
using Validator.Security;

namespace Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat
            {
                Name = "Kitty"
            };

            var dog = new Dog
            {
                Name = "Dogmeat"
            };

            Console.WriteLine($"{cat.Name} was {(cat.Accept(new DogClubSecurity()) ? "valid" : "not valid")} for entering the DogClub");
            Console.WriteLine($"{dog.Name} was {(dog.Accept(new DogClubSecurity()) ? "valid" : "not valid")} for entering the DogClub");
            Console.WriteLine($"{cat.Name} was {(cat.Accept(new CatClubSecurity()) ? "valid" : "not valid")} for entering the CatClub");
            Console.WriteLine($"{dog.Name} was {(dog.Accept(new CatClubSecurity()) ? "valid" : "not valid")} for entering the CatClub");
        }
    }
}