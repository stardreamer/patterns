import unittest

from selectors.EvenNumbersSelector import EvenNumbersSelector


class TestEvenNumbersSelector(unittest.TestCase):

    def test_should_return_empty_sequence_when_empty_sequence_is_given(self):
        empty_sequence = []
        selector = EvenNumbersSelector()

        self.assertTrue(len(selector.select(empty_sequence)) == 0)

    def test_should_return_empty_sequence_when_there_are_no_even_numbers(self):
        empty_sequence = [3, 5, 355, 321, 45]
        selector = EvenNumbersSelector()

        self.assertTrue(len(selector.select(empty_sequence)) == 0)

    def test_should_return_all_even_numbers_from_sequence(self):
        sequence = [1, 2, 3, 6, 4, 15, 23]
        correct_result_sequence = [2, 6, 4]
        selector = EvenNumbersSelector()

        self.assertEqual(correct_result_sequence, selector.select(sequence))

if __name__ == '__main__':
    unittest.main()
