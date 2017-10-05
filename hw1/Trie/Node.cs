using System.Collections.Generic;

namespace Utils
{
    public class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _next = new Dictionary<char, TrieNode>();

        private int _sizePrefix;
        private bool _isTerminate;

        public int Count()
        {
            return _next.Count;
        }

        public bool CheckElemInTree(string prefix)
        {
            if (prefix == null)
            {
                return false;
            }
            int index;
            var node = FindNode(prefix, out index);
            return index == prefix.Length && node != null ? node._isTerminate : false;
        }

        public bool InsertNode(TrieNode root, string prefix)
        {
            if (prefix == null)
            {
                return false;
            }
            var thisNode = root;
            thisNode.succCounter();

            foreach (var itemPrefix in prefix)
            {                
                if (!thisNode.CheckElemInChild(itemPrefix))
                {
                    thisNode.SetChild(itemPrefix);
                }
                thisNode = thisNode.GetChild(itemPrefix);
                thisNode.succCounter();
                
            }
            thisNode._isTerminate = true;
            return true;
        }

        public bool DeleteNode(TrieNode root, string prefix)
        {
            if (prefix == null)
            {
                return false;
            }
            var thisNode = root;
            thisNode.predCounter();

            foreach (var itemPrefix in prefix)
            {
                var perant = thisNode;
                thisNode = thisNode.GetChild(itemPrefix);
                thisNode.predCounter();

                if (thisNode.IsEmpty())
                {
                    perant.DelChild(itemPrefix);
                    return true;
                }
            }
            thisNode._isTerminate = false;
            return true;
        }

        public int HowManyPrefix(string prefix)
        {
            int index;
            var node = FindNode(prefix, out index);
            if (node == null || index != prefix.Length)
            {
                return 0;
            }
            return node._sizePrefix;
        }

        private bool IsEmpty()
        {
            return Count() == 0;
        }

        private void succCounter()
        {
            ++_sizePrefix;
        }

        private void predCounter()
        {
            --_sizePrefix;
        }

        private bool CheckElemInChild(char element)
        {
            return GetChild(element) != null;
        }

        private TrieNode  GetChild(char element)
        {
            return _next.ContainsKey(element) ? _next[element] : null; 
        }

        private void SetChild(char element)
        {
            _next.Add(element, new TrieNode());
        }

        private void DelChild(char element)
        {
            _next.Remove(element);
        }

        private TrieNode FindNode(string str, out int indexLast)
        {
            var thisNode = this;
            for (indexLast = 0; indexLast < str.Length && thisNode != null; ++indexLast)
            {
                thisNode = thisNode.GetChild(str[indexLast]);
            }
            return thisNode;
        }

    }
}