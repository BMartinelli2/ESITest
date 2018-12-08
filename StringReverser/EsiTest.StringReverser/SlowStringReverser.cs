using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace EsiTest.StringReverser
{
    /// <summary>
    /// This is a slow string reverser example.
    /// It iterates through the string multiple times to reverse and to split.
    /// Then it iterates through the words to find duplicates.
    /// Note: This class violates the single responsibility principle because it is doing two things.
    /// 1) Reversing an input string
    /// 2) Storing and parsing duplicate word counts.
    /// </summary>
    public class SlowStringReverser : IStringReverser
    {
        public const int DuplicateDisplayThreshold = 2;

        private const string ReversedStringHeader = "Reversed string!";
        private const string DuplicateWordHeader = "Words (spaces on each end) mentioned more than once:";
        private const string ErrorMessage = "Value must be at least 1.";
        private const string DuplicatesNotFoundMessage = " -- No duplicate words found --";

        private readonly Dictionary<string, int> _wordCounts = new Dictionary<string, int>();

        public string ReversedString { get; private set; }

        /// <summary>
        /// Displays results to the console.
        /// </summary>
        public void DisplayResults()
        {
            Console.WriteLine(ReversedStringHeader);
            Console.WriteLine(ReversedString);
            Console.WriteLine(DuplicateWordHeader);

            var duplicatedWords = GetWordCounts(DuplicateDisplayThreshold);

            if (duplicatedWords.Count == 0)
            {
                Console.WriteLine(DuplicatesNotFoundMessage);
            }

            foreach (var duplicateWord in duplicatedWords)
            {
                Console.WriteLine($"{duplicateWord.Item2} {duplicateWord.Item1}");
            }
            
        }

        /// <summary>
        /// Reverses the string and then counts any duplicate words.
        /// </summary>
        /// <param name="inputValue">Input value is the string to be parsed and analyzed.</param>
        public void ParseInputValue(string inputValue)
        {
            StoreReversedString(inputValue);
            StoreUniqueWordCount(inputValue);
        }

        /// <summary>
        /// Gets all words that are stored in the word count dictionary.
        /// </summary>
        /// <param name="duplicateThreshold">The duplicate threshold indicates the minimum amount of times for the word to appear.</param>
        /// <returns>Returns a <see cref="List{T}"/> of <see cref="Tuple{T1, T2}"/> which has the word and its count.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws an argument out of range exception if the threshold is below 1.</exception>
        public List<(int, string)> GetWordCounts(int duplicateThreshold)
        {
            if (duplicateThreshold <= 0)
            {
                throw new ArgumentOutOfRangeException(ErrorMessage);
            }

            var duplicateWords = new List<(int, string)>();

            foreach (var wordCountPair in _wordCounts)
            {
                if (wordCountPair.Value >= duplicateThreshold)
                {
                    duplicateWords.Add((wordCountPair.Value, wordCountPair.Key));
                }
            }

            return duplicateWords;
        }

        /// <summary>
        /// Stores all words in the input value string in a dictionary with the amount of times they appear.
        /// </summary>
        /// <param name="inputValue"></param>
        private void StoreUniqueWordCount(string inputValue)
        {
            string[] splitWords = Regex.Split(inputValue.ToLowerInvariant(), @"\W+");
            TextInfo currentCultureText = CultureInfo.CurrentCulture.TextInfo;
            foreach (string word in splitWords)
            {
                string properWord = currentCultureText.ToTitleCase(word);

                if (_wordCounts.ContainsKey(properWord))
                {
                    _wordCounts[properWord]++;
                }
                else
                {
                    _wordCounts.Add(properWord, 1);
                }
            }
        }

        /// <summary>
        /// Reverses the string and stores it locally.
        /// </summary>
        /// <param name="inputValue">The input string value to be reversed.</param>
        private void StoreReversedString(string inputValue)
        {
            ReversedString = new string(inputValue.Reverse().ToArray());
        }

    }
}