from GenericColletion.GenericEnumeratorBase import GenericEnumeratorBase


class GenericEnumerator(GenericEnumeratorBase):
    _readonly_collection = []
    _current_index = -1

    def __init__(self, readonly_collection: list):
        self._readonly_collection = readonly_collection

    def current(self) -> object:
        if self._current_index < 0:
            raise TypeError("Call move_next() first!")
        return self._readonly_collection[self._current_index]

    def move_next(self) -> bool:
        if self._current_index == len(self._readonly_collection) - 1:
            return False

        self._current_index += 1
        return True

    def reset(self):
        self._current_index = -1
