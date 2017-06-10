import unittest

from selectors.OddNumbersSelector import OddNumbersSelector


class TestEvenNumbersSelector(unittest.TestCase):

    def test_should_return_empty_sequence_when_empty_sequence_is_given(self):
        empty_sequence = []
        selector = OddNumbersSelector()

        self.assertTrue(len(selector.select(empty_sequence)) == 0)

    def test_should_return_empty_sequence_when_there_are_no_odd_numbers(self):
        empty_sequence = [4, 6, 44, 32, -4]
        selector = OddNumbersSelector()

        self.assertTrue(len(selector.select(empty_sequence)) == 0)

    def test_should_return_all_odd_numbers_from_sequence(self):
        sequence = [1, 2, 3, 6, 4, 15, 23, -3]
        correct_result_sequence = [1, 3, 15, 23, -3]
        selector = OddNumbersSelector()

        self.assertEqual(correct_result_sequence, selector.select(sequence))

if __name__ == '__main__':
    unittest.main()
