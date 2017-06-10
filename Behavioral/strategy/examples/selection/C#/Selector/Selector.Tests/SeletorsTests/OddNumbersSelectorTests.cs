using NUnit.Framework;
using Selector.Selectors;
using System.Collections.Generic;

namespace Selector.Tests.SeletorsTests
{
    [TestFixture]
    class OddNumbersSelectorTests
    {
        [Test]
        public void should_return_empty_sequence_when_empty_sequence_is_given()
        {
            var emptySequence = new List<int>();
            var selector = new OddNumbersSelector();

            Assert.IsEmpty(selector.Select(emptySequence));
        }

        [Test]
        public void should_return_empty_sequence_when_there_are_no_odd_numbers()
        {
            var oddSequence = new List<int>() { 4, 6, 44, 32, -4 };
            var selector = new OddNumbersSelector();

            Assert.IsEmpty(selector.Select(oddSequence));
        }

        [Test]
        public void should_return_all_even_numbers_from_sequence()
        {
            var testSequence = new List<int>() { 1, 2, 3, 6, 4, 15, 23, -3 };
            var correctResultSequence = new List<int>() { 1, 3, 15, 23, -3 };
            var selector = new OddNumbersSelector();

            CollectionAssert.AreEqual(correctResultSequence, selector.Select(testSequence));
        }
    }
}
