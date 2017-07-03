from Animals.Animal import Animal


class Cat(Animal):
    def accept(self, security) -> bool:
        return security.validate(self)
