namespace LeetCode
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

        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            // if total elements can not divided by group size...
            if (hand.Length % groupSize != 0)
            {
                return false;
            }


            var sortedDict = new SortedDictionary<int, int>();
            //put elements into sorted dictionary - this will record key and frequency of element in array
            foreach (int i in hand)
            {
                if (!sortedDict.ContainsKey(i))
                    sortedDict.Add(i, 0);

                sortedDict[i] += 1;
            }

            while (sortedDict.Count > 0)
            {
                var keys = sortedDict.Keys.ToArray();
                // if no of elements present in the dictionary is less than than the groupSize, stop
                if (keys.Length < groupSize)
                {
                    return false;
                }
                // get the first element of the group
                var start = keys[0];
               
                sortedDict[start] -= 1;
                // if it's now zero, we have used all of that particular key, so remove it
                if (sortedDict[start] == 0)
                {
                    sortedDict.Remove(start);
                }
                // next number
                int next = start + 1;

                for (int i = 1; i < groupSize; i++)
                {
                    // if the number is in the dictionary
                    if (keys[i] == next)
                    {
                        // reduce its count
                        sortedDict[next] -= 1;
                        // if it gets to zero, remove it & get the next number
                        if (sortedDict[next] == 0)
                        {
                            sortedDict.Remove(next);
                        }

                        next += 1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
