using System.Collections.Generic;

namespace Utils
{
    public class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _next = new Dictionary<char, TrieNode>();

        private int _sizePrefix;
        private bool _isTerminate;

        public bool InsertNode(TrieNode root, string prefix)
        {
            if (prefix == null)
            {
                return false;
            }
            var thisNode = root;
            thisNode.SuccCounter();

            foreach (var itemPrefix in prefix)
            {                
                if (!thisNode.CheckElemInChild(itemPrefix))
                {
                    thisNode.SetChild(itemPrefix);
                }
                thisNode = thisNode.GetChild(itemPrefix);
                thisNode.SuccCounter();
                
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
            thisNode.PredCounter();

            foreach (var itemPrefix in prefix)
            {
                var parent = thisNode;
                thisNode = thisNode.GetChild(itemPrefix);
                thisNode.PredCounter();

                if (thisNode.IsEmpty())
                {
                    parent.DelChild(itemPrefix);
                    return true;
                }
            }
            thisNode._isTerminate = false;
            return true;
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

        public int HowManyPrefix(string prefix)
        {
            int index;
            var node = FindNode(prefix, out index);
            return node == null || index != prefix.Length ? 0 : node._sizePrefix;
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

        private int Count() => _next.Count;

        private bool IsEmpty() => Count() == 0;

        private void SuccCounter() => ++_sizePrefix;

        private void PredCounter() =>  --_sizePrefix;

        private bool CheckElemInChild(char element) => GetChild(element) != null;

        private TrieNode GetChild(char element) =>  _next.ContainsKey(element) ? _next[element] : null;

        private void SetChild(char element) => _next.Add(element, new TrieNode());

        private void DelChild(char element) => _next.Remove(element);
    }
}