namespace LeetCode
{
    using System.Collections;
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

        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            Tree tree = new Tree();
            //split sentence
            var sentenceArray= sentence.Split(' ');
            for (int i = 0; i < dictionary.Count; ++i)
            {
                tree.insert(dictionary[i], i);
            }
            var ans = new ArrayList();
            foreach (string w in sentenceArray)
            {
                int idx = tree.search(w);
                //word found
                ans.Add(idx == -1 ? w : dictionary[idx]);
            }
            //arraylist needs to be converted back to an array
            return string.Join(" ", ans.ToArray());

        }
    }

    public class Tree
    {
        private Tree[] children = new Tree[26];
        private int reference = -1;
        //add word to tree
        public void insert(string w, int i)
        {
            Tree node = this;
            for (int j = 0; j < w.Length; ++j)
            {
                int idx = w.ToCharArray()[j] - 'a';
                if (node.children[idx] == null)
                {
                    node.children[idx] = new Tree();
                }
                node = node.children[idx];
            }
            node.reference = i;
        }
        //find word in tree
        public int search(string w)
        {
            Tree node = this;
            for (int j = 0; j < w.Length; ++j)
            {
                int idx = w.ToCharArray()[j] - 'a';
                if (node.children[idx] == null)
                {
                    return -1;
                }
                node = node.children[idx];
                if (node.reference != -1)
                {
                    return node.reference;
                }
            }
            return -1;
        }
    }
}
