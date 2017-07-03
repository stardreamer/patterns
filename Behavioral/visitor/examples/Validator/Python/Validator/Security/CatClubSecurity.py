from Animals.Animal import Animal
from Animals.Dog import Dog
from Security.Security import Security


class CatClubSecurity(Security):
    def validate(self, animal: Animal) -> bool:
        if isinstance(animal, Dog):
            return False
        return True
