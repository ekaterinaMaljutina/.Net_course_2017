
using System;
using trie;
using Xunit;

namespace test
{
    public class UnitTest1
    {

        private void setWordsInTrie(TrieImpl trieWords, string[] words)
        {

            for (int i = 0; i < words.Length; i++)
            {
                trieWords.Add(words[i]);
            }
        }

        [Fact]
        public void ContainsWords()
        {

            TrieImpl trie = new TrieImpl();

            string[] words = { "aaa", "bbb", "ccc", "abc", "abs", "bas", "baa" };
            setWordsInTrie(trie, words);

            for (int i = 0; i < words.Length; i++)
            {
                Assert.True(trie.Contains(words[i]));
            }

            Assert.False(trie.Contains("eee"));
        }

        [Fact]
        public void deleteWords()
        {
            TrieImpl TrieImpl = new TrieImpl();

            string[] words = { "aaa", "aab", "aac", "aabc" };

            setWordsInTrie(TrieImpl, words);

            for (int i = 0; i < words.Length; i++)
            {
                Assert.True(TrieImpl.Remove(words[i]));
            }

            Assert.False(TrieImpl.Remove("a"));

        }

        [Fact]
        public void checkSize()
        {
            TrieImpl TrieImpl = new TrieImpl();
            string[] words = { "a", "b", "c" };

            setWordsInTrie(TrieImpl, words);

            Assert.Equal(words.Length, TrieImpl.Size());

            string[] newWords = { "d", "e", "f" };

            setWordsInTrie(TrieImpl, newWords);

            Assert.Equal(words.Length + newWords.Length, TrieImpl.Size());

        }

        [Fact]
        public void checkPrefix()
        {
            TrieImpl TrieImpl = new TrieImpl();

            string[] words = { "aab", "aaa", "aac" };
            setWordsInTrie(TrieImpl, words);

            Assert.Equal(3, TrieImpl.HowManyStartsWithPrefix("aa"));
            Assert.Equal(3, TrieImpl.HowManyStartsWithPrefix("a"));
            Assert.Equal(0, TrieImpl.HowManyStartsWithPrefix("b"));
        }

        [Fact]
        public void checkTypicalCases()
        {

            TrieImpl TrieImpl = new TrieImpl();
            string[] words = { "aaa", "bbb", "a", "b", "c", "ac", "ab", "ba", "bb" };
            setWordsInTrie(TrieImpl, words);

            Assert.True(TrieImpl.Contains("a"));
            Assert.Equal(words.Length, TrieImpl.Size());

            TrieImpl.Remove("a");

            Assert.False(TrieImpl.Contains("a"));
            Assert.Equal(words.Length - 1, TrieImpl.Size());

            Assert.Equal(1, TrieImpl.HowManyStartsWithPrefix("c"));

            TrieImpl.Remove("c");

            Assert.Equal(0, TrieImpl.HowManyStartsWithPrefix("c"));
            Assert.Equal(words.Length - 2, TrieImpl.Size());

        }
    }
}