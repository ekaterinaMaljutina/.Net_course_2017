using System;
using Utils;
using ITrie_HW;

namespace Trie_HW
{
    public class Trie : ITrie
    {
        private readonly TrieNode _root = new TrieNode();
        private int _size = 0;

        public bool Add(string element)
        {
            if (Contains(element))
            {
                return false;
            }
            _size++;
            return _root.InsertNode(_root, element);
        }

        public bool Contains(string element)
        {
            return _root.CheckElemInTree(element);
        }

        public bool Remove(string element)
        {
            if (!Contains(element))
            {
                return false;
            }
            _size--;
            return _root.DeleteNode(_root, element);
        }

        public int Size()
        {
            return _size;
        }

        public int HowManyStartsWithPrefix(string prefix)
        {
            return _root.HowManyPrefix(prefix);
        }

    }
}