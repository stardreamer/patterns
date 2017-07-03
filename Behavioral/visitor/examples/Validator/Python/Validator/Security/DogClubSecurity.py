from Animals.Cat import Cat
from Animals.Animal import Animal
from Security.Security import Security


class DogClubSecurity(Security):
    def validate(self, animal: Animal) -> bool:
        if isinstance(animal, Cat):
            return False
        return True
