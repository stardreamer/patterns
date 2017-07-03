from Animals.Animal import Animal


class Dog(Animal):
    def accept(self, security) -> bool:
        return security.validate(self)
