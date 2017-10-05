using System;
using Trie_HW;
using NUnit.Framework;

namespace Test
{
    public class TestTrie
    {

        private static void SetWordsInTrie(Trie trieWords, string[] words)
        {
            foreach (var word in words)
            {
                trieWords.Add(word);
            }
        }

        [Test]
        public void ContainsWords()
        {

            var trie = new Trie();

            string[] words = { "aaa", "bbb", "ccc", "abc", "abs", "bas", "baa" };
            SetWordsInTrie(trie, words);

            foreach (var word in words)
            {
                Assert.True(trie.Contains(word));
            }

            Assert.False(trie.Contains("eee"));
        }

        [Test]
        public void DeleteWords()
        {
            var trie = new Trie();

            string[] words = { "aaa", "aab", "aac", "aabc" };

            SetWordsInTrie(trie, words);
            foreach (var word in words)
            {
                Assert.True(trie.Remove(word));
                Assert.False(trie.Contains(word));
            }

            Assert.False(trie.Contains("a"));
            Assert.False(trie.Remove("a"));
        }

        [Test]
        public void CheckSizeAfterAdd()
        {
            var trie = new Trie();
            string[] words = { "a", "b", "c" };

            SetWordsInTrie(trie, words);

            Assert.AreEqual(words.Length, trie.Size());

            string[] newWords = { "d", "e", "f" };

            SetWordsInTrie(trie, newWords);

            Assert.AreEqual(words.Length + newWords.Length, trie.Size());

        }

        [Test]
        public void CheckPrefix()
        {
            var trie = new Trie();

            string[] words = { "aab", "aaa", "aac" };
            SetWordsInTrie(trie, words);

            Assert.AreEqual(3, trie.HowManyStartsWithPrefix("aa"));
            Assert.AreEqual(3, trie.HowManyStartsWithPrefix("a"));
            Assert.AreEqual(1, trie.HowManyStartsWithPrefix("aaa"));
            Assert.AreEqual(1, trie.HowManyStartsWithPrefix("aab"));
            Assert.AreEqual(1, trie.HowManyStartsWithPrefix("aac"));
            Assert.AreEqual(0, trie.HowManyStartsWithPrefix("b"));
        }

        [Test]
        public void CheckRussianSymbols()
        {
            var trie = new Trie();
            string[] words = { "абвгд", "абв", "аб", "а" };
            SetWordsInTrie(trie, words);

            Assert.IsTrue(trie.Contains(words[0]));
            Assert.IsFalse(trie.Contains("русс"));

            Assert.IsTrue(trie.Remove(words[0]));
            Assert.IsFalse(trie.Contains(words[0]));
        }

        [Test]
        public void CheckOtherSymbols()
        {
            var trie = new Trie();
            string[] words = { "81/*&!", "8@#$", "(/.<,", "$$/?'" };
            SetWordsInTrie(trie, words);

            Assert.IsTrue(trie.Contains(words[1]));
            Assert.IsFalse(trie.Contains("$$"));

            Assert.IsTrue(trie.Remove(words[2]));
            Assert.IsFalse(trie.Contains(words[2]));
        }

        [Test]
        public void HowToManyPrefixAfterRemove()
        {
            var trie = new Trie();
            string[] words = { "aaa", "bbb", "a", "b", "c", "ac", "ab", "ba", "bb" };
            SetWordsInTrie(trie, words);

            Assert.AreEqual(1, trie.HowManyStartsWithPrefix("c"));

            trie.Remove("c");

            Assert.AreEqual(0, trie.HowManyStartsWithPrefix("c"));
        }


        [Test]
        public void CheckSizeAfterRemove()
        {

            var trie = new Trie();
            string[] words = { "aaa", "bbb", "a", "b", "c", "ac", "ab", "ba", "bb" };
            SetWordsInTrie(trie, words);

            Assert.AreEqual(words.Length, trie.Size());
            Assert.True(trie.Remove(words[3]));
            Assert.AreEqual(words.Length - 1, trie.Size());

            Assert.True(trie.Remove(words[2]));
            Assert.AreEqual(words.Length - 2, trie.Size());

            Assert.True(trie.Remove(words[1]));
            Assert.True(trie.Remove(words[0]));
            Assert.AreEqual(words.Length - 4, trie.Size());
        }

        [Test]
        public void SetNullValue()
        {
            var trie = new Trie();
            trie.Add(null);
            Assert.AreEqual(0, trie.Size());
        }

        [Test]
        public void RemoveNullValue()
        {
            var trie = new Trie();
            trie.Add("a");
            Assert.AreEqual(1, trie.Size());

            Assert.False(trie.Remove(null));
        }

        [Test]
        public void ContainsNullValue()
        {
            var trie = new Trie();
            trie.Add("a");
            Assert.AreEqual(1, trie.Size());

            Assert.False(trie.Contains(null));
        }
            
    }
}