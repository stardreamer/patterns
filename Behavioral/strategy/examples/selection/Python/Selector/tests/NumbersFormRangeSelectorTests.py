import unittest

from selectors.NumbersFormRangeSelector import NumbersFormRangeSelector


class TestNumbersFormRangeSelector(unittest.TestCase):
    def test_should_return_empty_sequence_when_empty_sequence_is_given(self):
        empty_sequence = []
        selector = NumbersFormRangeSelector(1, 10)

        self.assertTrue(len(selector.select(empty_sequence)) == 0)

    def test_should_return_empty_sequence_when_there_are_no_numbers_from_range(self):
        empty_sequence = [3, 5, 355, 321, 45]
        selector = NumbersFormRangeSelector(-8, 0)

        self.assertTrue(len(selector.select(empty_sequence)) == 0)

    def test_should_return_all_numbers_from_range(self):
        sequence = [1, 2, 3, 6, 4, 15, 23]
        correct_result_sequence = [2, 3, 6, 4]
        selector = NumbersFormRangeSelector(2, 6)

        self.assertEqual(correct_result_sequence, selector.select(sequence))

    def test_should_throw_exception_when_wrong_range_is_given(self):
        with self.assertRaises(ValueError):
            NumbersFormRangeSelector(100, 6)

if __name__ == '__main__':
    unittest.main()
