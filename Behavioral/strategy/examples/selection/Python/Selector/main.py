from selectors.BaseSeletor import BaseSelector
from selectors.EvenNumbersSelector import EvenNumbersSelector
from selectors.NumbersFormRangeSelector import NumbersFormRangeSelector

from selectors.OddNumbersSelector import OddNumbersSelector


def print_selected_elements(source: list, strategy: BaseSelector):
    print(source)
    for val in strategy.select(source):
        print("Selected element: " + str(val))

sourceList = [1, 2, 3, 4, 5, 6, -4, -1, -455, 2, 1, 456, 783, 12, 45, 90, 24]

print("Selecting even numbers")
print_selected_elements(sourceList, EvenNumbersSelector())

print("Selecting odd numbers")
print_selected_elements(sourceList, OddNumbersSelector())

print("Selecting numbers in range [1, 20]")
print_selected_elements(sourceList, NumbersFormRangeSelector(1, 20))
