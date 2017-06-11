from generators.EnglishNameGenerator import EnglishNameGenerator
from generators.RussianNameGenerator import RussianNameGenerator
from generators.GermanNameGenerator import GermanNameGenerator
from generators.BaseNameGenerator import BaseNameGenerator


def print_random_name(generator: BaseNameGenerator):
    print(generator.get_name())

print("Generating russian name.")
print_random_name(RussianNameGenerator())
print("Generating english name.")
print_random_name(EnglishNameGenerator())
print("Generating german name.")
print_random_name(GermanNameGenerator())
