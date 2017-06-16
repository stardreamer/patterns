from GenericColletion.GenericEnumeratorBase import GenericEnumeratorBase


class GenericEnumerableBase:
    def get_enumerator(self) -> GenericEnumeratorBase:
        raise NotImplemented()

