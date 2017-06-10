from selectors.BaseSeletor import BaseSelector


class EvenNumbersSelector(BaseSelector):
    def select(self, source: list) -> list:
        result = []
        for val in source:
            if val % 2 == 0:
                result.append(val)
        return result
