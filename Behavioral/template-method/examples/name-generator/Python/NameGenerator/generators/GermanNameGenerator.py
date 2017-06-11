from generators.BaseNameGenerator import BaseNameGenerator, Gender
import random


class GermanNameGenerator(BaseNameGenerator):
    __first_male_names = ["Hans", "Heinz", "Horst", "Andreas"]
    __first_female_names = ["Anna", "Elke", "Birgit", "Stefanie"]
    __surnames = ["Müller", "Schröder", "Hartmann", "Schulze"]

    def generate_first_name(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__first_male_names[random.randint(0, len(self.__first_male_names)-1)]
        return self.__first_female_names[random.randint(0, len(self.__first_female_names)-1)]

    def generate_surname(self, gender: Gender) -> str:
        return self.__surnames[random.randint(0, len(self.__surnames)-1)]
