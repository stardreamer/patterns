from generators.BaseNameGenerator import BaseNameGenerator, Gender
import random


class RussianNameGenerator(BaseNameGenerator):
    __first_male_names = ["Антон", "Олег", "Роман", "Виктор"]
    __first_female_names = ["Виктория", "Светлана", "Катерина", "Ольга"]
    __surnames = ["Петров", "Семенов", "Иванов", "Борисов"]

    def generate_first_name(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__first_male_names[random.randint(0, len(self.__first_male_names)-1)]
        return self.__first_female_names[random.randint(0, len(self.__first_female_names)-1)]

    def generate_surname(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__surnames[random.randint(0, len(self.__surnames)-1)]
        return self.__surnames[random.randint(0, len(self.__surnames)-1)]+"а"
