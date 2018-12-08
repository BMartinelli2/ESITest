using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace EsiTest.StringReverser.UnitTests
{
    public class SlowStringReverserTests
    {
        private SlowStringReverser _slowStringReverser;

        [SetUp]
        public void Setup()
        {
            _slowStringReverser = new SlowStringReverser();
        }

        /// <summary>
        /// Verify the string reverses order
        /// </summary>
        [Test]
        public void ReverseString_StringReverses()
        {
            //Setup:
            const string testInput = "Jacque Olson has eaten a ton of broccoli this month.";
            const string expectedOutput = ".htnom siht iloccorb fo not a netae sah noslO euqcaJ";

            //Execute:
            _slowStringReverser.ParseInputValue(testInput);
            string actualResult = _slowStringReverser.ReversedString;

            //Assert:
            Assert.That(actualResult, Is.EqualTo(expectedOutput));
        }


        /// <summary>
        /// This is a bad test because it doesn't really test if the string is reversed.
        /// However it does verify that palindromes are the same forwards and backwards.
        /// </summary>
        [Test]
        public void ReverseString_StringReversesAPalindrome()
        {
            //Setup:
            const string testInput = "never oddo reven";

            //Execute:
            _slowStringReverser.ParseInputValue(testInput);
            string actualResult = _slowStringReverser.ReversedString;

            //Assert:
            Assert.That(actualResult, Is.EqualTo(testInput));
        }

        [Test]
        public void GetWordCounts_NoPunctuations()
        {
            //Setup:
            TextInfo currentCultureText = CultureInfo.CurrentCulture.TextInfo;
            const string testInput = "odd odd odd even even odd odd odd mold";
            List<(int, string)> expectedOutput = new List<(int, string)>
            {
                (6, currentCultureText.ToTitleCase("odd")),
                (2, currentCultureText.ToTitleCase("even"))
            };

            //Execute:
            _slowStringReverser.ParseInputValue(testInput);
            List<(int, string)> actualOutput = _slowStringReverser.GetWordCounts(SlowStringReverser.DuplicateDisplayThreshold);

            //Assert:
            Assert.That(actualOutput, Is.Not.Null);
            Assert.That(actualOutput.Count, Is.EqualTo(expectedOutput.Count));
            CollectionAssert.AreEquivalent(expectedOutput, actualOutput);
        }

        [Test]
        public void GetWordCounts_WithPunctuations()
        {
            //Setup:
            TextInfo currentCultureText = CultureInfo.CurrentCulture.TextInfo;
            const string testInput = "ood odd odd!!!!! odd... even? even odd\r\n odd odd mold";
            List<(int, string)> expectedOutput = new List<(int, string)>
            {
                (6, currentCultureText.ToTitleCase("odd")),
                (2, currentCultureText.ToTitleCase("even"))
            };

            //Execute:
            _slowStringReverser.ParseInputValue(testInput);
            List<(int, string)> actualOutput = _slowStringReverser.GetWordCounts(SlowStringReverser.DuplicateDisplayThreshold);

            //Assert:
            Assert.That(actualOutput, Is.Not.Null);
            Assert.That(actualOutput.Count, Is.EqualTo(expectedOutput.Count));
            CollectionAssert.AreEquivalent(expectedOutput, actualOutput);
        }

        [Test]
        public void GetWordCounts_CaseInsensitivity()
        {
            //Setup:
            TextInfo currentCultureText = CultureInfo.CurrentCulture.TextInfo;
            const string testInput = "odd ODD oDd EveN even oDD odd odd mold";
            List<(int, string)> expectedOutput = new List<(int, string)>
            {
                (6, currentCultureText.ToTitleCase("odd")),
                (2, currentCultureText.ToTitleCase("even"))
            };

            //Execute:
            _slowStringReverser.ParseInputValue(testInput);
            List<(int, string)> actualOutput = _slowStringReverser.GetWordCounts(SlowStringReverser.DuplicateDisplayThreshold);

            //Assert:
            Assert.That(actualOutput, Is.Not.Null);
            Assert.That(actualOutput.Count, Is.EqualTo(expectedOutput.Count));
            CollectionAssert.AreEquivalent(expectedOutput, actualOutput);
        }

        [Test]
        public void GetWordCounts_AlternateThreshold()
        {
            //Setup:
            TextInfo currentCultureText = CultureInfo.CurrentCulture.TextInfo;
            const int lowThreshold = 1;
            const string testInput = "odd ODD oDd EveN even oDD odd odd mold";
            List<(int, string)> expectedOutput = new List<(int, string)>
            {
                (6, currentCultureText.ToTitleCase("odd")),
                (2, currentCultureText.ToTitleCase("even")),
                (1, currentCultureText.ToTitleCase("mold")),
            };

            //Execute:
            _slowStringReverser.ParseInputValue(testInput);
            List<(int, string)> actualOutput = _slowStringReverser.GetWordCounts(lowThreshold);

            //Assert:
            Assert.That(actualOutput, Is.Not.Null);
            Assert.That(actualOutput.Count, Is.EqualTo(expectedOutput.Count));
            CollectionAssert.AreEquivalent(expectedOutput, actualOutput);
        }

        [Test]
        public void GetWordCounts_InvalidThreshold()
        {
            //Setup:
            TextInfo currentCultureText = CultureInfo.CurrentCulture.TextInfo;
            const int badThreshold = -1;
            const string testInput = "odd ODD oDd EveN even oDD odd odd mold";
            const string expectedExceptionMessage = "Value must be at least 1.";

            //Execute:
            ArgumentOutOfRangeException badValueException = null;
            List<(int, string)> actualOutput = null;
            try
            {
                _slowStringReverser.ParseInputValue(testInput);
                actualOutput = _slowStringReverser.GetWordCounts(badThreshold);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                badValueException = ex;
            }

            //Assert:
            Assert.That(badValueException, Is.Not.Null);
            Assert.That(badValueException.Message, Is.EqualTo(expectedExceptionMessage));
            Assert.That(actualOutput, Is.Null);
        }
    }
}