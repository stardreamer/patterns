from Security.CatClubSecurity import CatClubSecurity
from Security.DogClubSecurity import DogClubSecurity
from Animals.Cat import Cat
from Animals.Dog import Dog

cat = Cat("Kitty")
dog = Dog("Dogmeat")

print(cat.Name + " was " + ("valid" if cat.accept(DogClubSecurity()) else "not valid") + " for entering the DogClub")
print(dog.Name + " was " + ("valid" if dog.accept(DogClubSecurity()) else "not valid") + " for entering the DogClub")
print(cat.Name + " was " + ("valid" if cat.accept(CatClubSecurity()) else "not valid") + " for entering the CatClub")
print(dog.Name + " was " + ("valid" if dog.accept(CatClubSecurity()) else "not valid") + " for entering the CatClub")
