from GenericColletion.GenericCollection import  GenericCollection


objectsOfInterest = [1, "covfefe", 123.4, True]

generic_collection = GenericCollection(objectsOfInterest)
generic_collection_enumerator = generic_collection.get_enumerator()

print("Iterating through our GenericCollection")
while generic_collection_enumerator.move_next():
    print(generic_collection_enumerator.current())

print("\nIterating through builtin collection")
builtin_iterator = iter(objectsOfInterest)
try:
    while True:
        print(next(builtin_iterator))
except StopIteration:
    print("Builtin iterator reached its end.")
