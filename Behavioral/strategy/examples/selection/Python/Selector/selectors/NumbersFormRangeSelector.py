from selectors.BaseSeletor import BaseSelector


class NumbersFormRangeSelector(BaseSelector):
    segmentStart = 0
    segmentEnd = 0

    def __init__(self, segmentstart:int, segmentend:int):
        self.segmentStart = segmentstart
        self.segmentEnd = segmentend

        if self.segmentStart >= self.segmentEnd:
            raise ValueError()

    def select(self, source: list) -> list:
        result = []
        for val in source:
            if self.segmentStart <= val <= self.segmentEnd:
                result.append(val)
        return result
