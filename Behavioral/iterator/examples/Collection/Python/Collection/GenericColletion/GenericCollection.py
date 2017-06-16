from GenericColletion.GenericEnumerableBase import GenericEnumerableBase
from GenericColletion.GenericEnumeratorBase import GenericEnumeratorBase
from GenericColletion.GenericEnumerator import GenericEnumerator


class GenericCollection(GenericEnumerableBase):
    _list_of_interest = []

    def __init__(self, list_of_interest: list):
        self._list_of_interest = list_of_interest

    def get_enumerator(self) -> GenericEnumeratorBase:
        return GenericEnumerator(self._list_of_interest)
