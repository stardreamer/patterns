class GenericEnumeratorBase:
    def current(self) -> object:
        raise NotImplemented()

    def move_next(self) -> bool:
        raise NotImplemented()

    def reset(self):
        pass
