namespace LeetCodeTests
{
    using LeetCode;
    using System.Data;

    public class Tests
    {
        private readonly Solution solution = new Solution();

        [TestCase("abc", "pqr", "apbqcr")]
        [TestCase("ab", "pqrs", "apbqrs")]
        [TestCase("abcd", "pq", "apbqcd")]
        public void MergeAlternatelyReturnsMergedString(string word1, string word2, string expected)
        {
            var actual = solution.MergeAlternately(word1, word2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ScoreOfStringReturnsAbsoluteScore()
        {
            var expected = 13;
            var actual = solution.ScoreOfString("hello");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ScoreOfStringReturnsZeroisWordIsNullOrempty(string? input)
        {
            var expected =0;
            var actual = solution.ScoreOfString(input!);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ReverseStringReturnsReversedString()
        {
            var expected = new char[] { 'o', 'l', 'l', 'e', 'h' };
            var actual = solution.ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("coaching", "coding", 4)]
        [TestCase("abcde", "a", 0)]
        [TestCase("z", "abcde", 5)]
        public void AppendCharactersReturnsNumberofCharactersSpecified(string s, string t, int expected)
        {
            var actual = solution.AppendCharacters(s, t);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("", "abcde")]
        [TestCase(null, "abcde")]
        public void AppendCharactersReturnsZeroWithNullOrEmptySValue(string? s, string t)
        {
            var actual = solution.AppendCharacters(s!, t);
            Assert.That(actual, Is.EqualTo(0));
        }

        [TestCase("abccccdd",7)]
        [TestCase("a", 1)]
        public void LongestPalindromeReturnsExpectedValue(string input, int expected)
        {
            var actual =solution.LongestPalindrome(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("")]
        [TestCase(null)]
        public void LongestPalindromeReturnsZeroifInputIsNullOrEmpty(string? input)
        {
            var actual = solution.LongestPalindrome(input!);
            Assert.That(actual, Is.EqualTo(0));
        }

        [TestCase(new object[] { "bella", "label", "roller" }, new object[] { "e", "l", "l" })]
        [TestCase(new object[] { "cool", "lock", "cook" }, new object[] { "c", "o" })]
        public void CommonCharsReturnsListOfLetters(object[] input, object[] expected)
        {
            var words =input.Select(o => o.ToString()).ToArray();
            var expectedList = expected.ToList();
            var actual = solution.CommonChars(words!);

            foreach (var item in actual)
            {
                Assert.That(expectedList.Contains(item));
            }
        }

        [Test]
        public void CommonCharsReturnsOutOfRangeErrorIfWordsLengthEqualsOne()
        {
            var words = new[] { "hello" };
            Assert.Throws<ArgumentOutOfRangeException>(()=> solution.CommonChars(words));
        }

        [Test]
        public void CommonCharsReturnsOutOfRangeErrorIfAnyWordInWordsIsLongerThan100Chars()
        {
            var words = new[] { "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz" };
            Assert.Throws<ArgumentOutOfRangeException>(() => solution.CommonChars(words));
        }

        [TestCase(new object[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3)]
        public void IsNStraightHandReturnsTrueIfMultipleHandsReturned(object[] input, int groupSize)
        {
            var nums = input.Select(o => (int)o).ToArray();
            var actual = solution.IsNStraightHand(nums, groupSize);
            Assert.That(actual, Is.True);
        }

        [TestCase(new object[] { 1, 2, 3, 4, 5 }, 4)]
        public void IsNStraightHandReturnsFalseIfMultipleHandsCannnotBeReturned(object[] input, int groupSize)
        {
            var nums = input.Select(o => (int)o).ToArray();
            var actual = solution.IsNStraightHand(nums, groupSize);
            Assert.That(actual, Is.False);
        }



        [TestCase(new[] { "cat", "bat", "rat" }, "the cattle was rattled by the battery", "the cat was rat by the bat")]
        [TestCase(new [] { "a", "b", "c" }, "aadsfasf absbs bbab cadsfafs", "a a b c")]
        [TestCase(new[] { "catt","cat", "bat", "rat" }, "the cattle was rattled by the battery", "the cat was rat by the bat")]
        public void ReplaceWordsReturnsSentence(string[] dictionary, string sentence, string expected)
        {
            var actual = solution.ReplaceWords(dictionary.ToList(), sentence);
            Assert.That(actual,Is.EqualTo(expected));
        }
    }
}