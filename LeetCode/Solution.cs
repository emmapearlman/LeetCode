namespace LeetCode
{
    using System.Collections.ObjectModel;
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

        public char[] ReverseString(char[] s)
        {
            int l = 0;
            int r = s.Length - 1;

            while (l < r)
            {
                char temp = s[l];
                s[l++] = s[r];
                s[r--] = temp;
            }
            //Console.WriteLine("[{0}]", string.Join(", ", s));
            return s;
        }

        public int AppendCharacters(string s, string t)
        {
            int j = 0;
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            int n = s.Length;
            int m = t.Length;

            for (int i = 0; i < n; i++)
            {
                if (s.Substring(i, 1) == t.Substring(j, 1))
                {
                    j++;
                    if (j == m)
                    {
                        break;
                    }
                }
            }
            return m - j;
        }

        public IList<string> CommonChars(string[] words)
        {
            Collection<string> result = new Collection<string>();

            try
            {
                if (words.Length <= 1 || words.Length >= 100)
                {
                    throw new ArgumentOutOfRangeException("words is the wrong length");
                }
                //can't be more than 26 because 26 letters in alphabet
                var current = new int[26];
                for (int i = 0; i < 26; i++)
                    current[i] = int.MaxValue;

                foreach (var word in words)
                {
                    if (word.Length >= 100)
                    {
                        throw new ArgumentOutOfRangeException("word is the too long");
                    }
                    //like above
                    var temp = new int[26];
                    foreach (var ch in word)
                        temp[ch - 'a']++;

                    for (int i = 0; i < 26; i++)
                        current[i] = Math.Min(current[i], temp[i]);
                }
                for (int i = 0; i < 26; i++)
                {
                    while (current[i]-- > 0)
                    {// populate result collection
                        result.Add(((char)('a' + i)).ToString());
                    }
                }


            }
            catch (ArgumentOutOfRangeException aorEx)
            {
                throw aorEx;
            }
            catch (Exception)
            {

                throw;
            }
            //turn it into a list
            return result.ToList(); 
        }

    }
}
