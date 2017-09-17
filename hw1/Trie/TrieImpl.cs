using System;
using node;

namespace trie
{
    public class TrieImpl : Trie
    {
        private Node root = new Node();
        private int size = 0;

        public bool Add(string element)
        {
            if (Contains(element))
            {
                return false;
            }
            size++;
            return root.insertNode(root, element);
        }

        public bool Contains(string element)
        {
            return root.checkElemInTree(element);
        }

        public bool Remove(string element)
        {
            if (!Contains(element))
            {
                return false;
            }
            size--;
            return root.deleteNode(root, element);
        }
        public int Size()
        {
            return size;
        }

        public int HowManyStartsWithPrefix(string prefix)
        {
            return root.howManyPrefix(prefix);
        }

    }
}