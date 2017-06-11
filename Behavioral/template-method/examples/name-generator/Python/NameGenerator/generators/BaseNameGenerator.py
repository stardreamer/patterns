from enum import Enum
import random


class Gender(Enum):
    MALE = 1
    FEMALE = 2


class BaseNameGenerator:
    @staticmethod
    def get_random_gender() -> Gender:
        if random.randint(1, 2) == 1:
            return Gender.MALE
        return Gender.FEMALE

    def generate_first_name(self, gender: Gender) -> str:
        pass

    def generate_surname(self, gender: Gender) -> str:
        pass

    def get_name(self)-> str:
        gender = self.get_random_gender()
        return self.generate_first_name(gender) + " " + self.generate_surname(gender)
