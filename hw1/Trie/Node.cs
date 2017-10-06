using System.Collections.Generic;

namespace Utils
{
    public class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _next;
        private readonly  TrieNode _parent;
        private readonly char _value;

        private int _sizePrefix { set; get; }

        private bool _isTerminate { set; get; }

       
        public TrieNode(TrieNode _parent, char _value)
        {
            this._parent = _parent;
            this._value = _value;
            _next = new Dictionary<char, TrieNode>();
        }


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

            var idx = 0;
            for (; idx < prefix.Length; ++idx)
            {
                thisNode = thisNode.GetChild(prefix[idx]);

                if (thisNode == null)
                {
                    break;
                }
                thisNode.PredCounter();
            }
            if (idx != prefix.Length || thisNode == null || !thisNode._isTerminate)
            {
                return false;                
            }

            thisNode._isTerminate = false;

            while (thisNode._parent != null && !thisNode._isTerminate && thisNode.IsEmpty())
            {
                var parent = thisNode._parent;
                parent.DelChild(thisNode._value);
                thisNode = parent;
            }

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

        private void SetChild(char element) => _next.Add(element, new TrieNode(this, element));

        private void DelChild(char element) => _next.Remove(element);
    }
}