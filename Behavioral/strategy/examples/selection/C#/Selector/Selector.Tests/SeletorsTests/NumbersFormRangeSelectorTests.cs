using NUnit.Framework;
using Selector.Selectors;
using System;
using System.Collections.Generic;

namespace Selector.Tests.SeletorsTests
{
    [TestFixture]
    public class NumbersFormRangeSelectorTests
    {
        [Test]
        public void should_return_empty_sequence_when_empty_sequence_is_given()
        {
            var emptySequence = new List<int>();
            var selector = new NumbersFormRangeSelector(1, 4);

            Assert.IsEmpty(selector.Select(emptySequence));
        }

        [Test]
        public void should_return_empty_sequence_when_there_are_no_numbers_from_range()
        {
            var oddSequence = new List<int>() { 3, 5, 355, 321, 45 };
            var selector = new NumbersFormRangeSelector(-2, -1);

            Assert.IsEmpty(selector.Select(oddSequence));
        }

        [Test]
        public void should_return_all_numbers_from_range()
        {
            var testSequence = new List<int>() { 1, 2, 3, 6, 4, 15, 23 };
            var correctResultSequence = new List<int>() { 2, 3, 6, 4 };
            var selector = new NumbersFormRangeSelector(2, 6);

            CollectionAssert.AreEqual(correctResultSequence, selector.Select(testSequence));
        }

        [Test]
        public void should_throw_exception_when_wrong_range_is_given()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new NumbersFormRangeSelector(2, -8));
        }
    }
}
