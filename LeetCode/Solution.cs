﻿namespace LeetCode
{
    using System.Linq;
    using System.Text;

    public class Solution
    {
        public string MergeAlternately(string word1, string word2)
        {
            StringBuilder sb = new StringBuilder();

            string[] word1Array = word1.ToCharArray().Select(c => c.ToString()).ToArray();
            string[] word2Array = word2.ToCharArray().Select(c => c.ToString()).ToArray();
            if (word2Array.Length > word1Array.Length)
            {
                word2Array = word2Array.Take(word1Array.Length).ToArray();
            }
            if (word1Array.Length > word2Array.Length)
            {
                word1Array = word1Array.Take(word2Array.Length).ToArray();
            }
            for (int i = 0; i <= word1Array.Length - 1; i++)
            {
                sb.Append(word1Array[i]);
                sb.Append(word2Array[i]);

            }
            if (word2.Length > word1.Length)
            {
                var diff = word2.Length - word1.Length;
                var extra = word2.Substring(word1.Length, diff);
                sb.Append(extra.ToString());
            }
            if (word1.Length > word2.Length)
            {
                var diff = word1.Length - word2.Length;
                var extra = word1.Substring(word2.Length, diff);
                sb.Append(extra.ToString());
            }
            return sb.ToString();
        }

        public int ScoreOfString(string s)
        {
            int score = 0;
            int diff = 0;

            if (string.IsNullOrEmpty(s))
            {
                return score;
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);

            int i = 0;
            while (i < asciiBytes.Length)
            {
                if (i + 1 == asciiBytes.Length)
                {
                    break;
                }
                diff = Math.Abs(asciiBytes[i] - asciiBytes[i + 1]);
                score += diff;
                i++;
            }



            return score;

        }
    }
}
