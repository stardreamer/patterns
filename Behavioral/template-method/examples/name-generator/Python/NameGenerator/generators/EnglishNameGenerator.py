from generators.BaseNameGenerator import BaseNameGenerator, Gender
import random


class EnglishNameGenerator(BaseNameGenerator):
    __first_male_names = ["Jim", "Richard", "Ted", "Robert", "Danny"]
    __first_female_names = ["Kate", "Susan", "Victoria", "Diana"]
    __surnames = ["Smith", "Black", "Robinson", "Rand"]

    def generate_first_name(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__first_male_names[random.randint(0, len(self.__first_male_names)-1)]
        return self.__first_female_names[random.randint(0, len(self.__first_female_names)-1)]

    def generate_surname(self, gender: Gender) -> str:
        return self.__surnames[random.randint(0, len(self.__surnames)-1)]
