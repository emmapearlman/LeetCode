namespace LeetCodeTests
{
    using LeetCode;

    public class Tests
    {
        private readonly Solution solution = new Solution();

        [TestCase("abc", "pqr","apbqcr")]
        [TestCase("ab", "pqrs", "apbqrs")]
        [TestCase("abcd", "pq", "apbqcd")]
        public void MergeAlternatelyReturnsMergedString(string word1, string word2, string expected)
        {
            var actual =solution.MergeAlternately(word1, word2);
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
            var actual = solution.ReverseString(new char[] { 'h', 'e','l','l','o' });
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("coaching", "coding", 4 )]
        [TestCase("abcde", "a", 0)]
        [TestCase("z", "abcde", 5)]
        public void AppendCharactersReturnsNumberofCharactersSpecified(string s, string t, int expected)
        {
            var actual = solution.AppendCharacters( s, t );
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


    }
}