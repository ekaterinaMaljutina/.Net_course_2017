namespace node
{
    public class Node
    {
        private const int SIZE = 'Z' + 'z' - 'A' - 'a' + 2;

        private Node[] next = new Node[SIZE];
        private int counter;
        private bool isTerminate;

        public bool checkElemInTree(string str)
        {
            Node node = findNode(str);
            return node != null && node.isTerminate;
        }

        public bool insertNode(Node root, string str)
        {
            Node thisNode = root;
            thisNode.succCounter();

            for (int i = 0; i < str.Length; i++)
            {
                if (!thisNode.checkElemInChild(str[i]))
                {
                    thisNode.setChild(str[i]);
                }
                thisNode = thisNode.getChild(str[i]);
                thisNode.succCounter();
            }
            thisNode.isTerminate = true;
            return true;
        }

        public bool deleteNode(Node root, string str)
        {
            Node thisNode = root;
            thisNode.predCounter();

            for (int i = 0; i < str.Length; i++)
            {
                thisNode = thisNode.getChild(str[i]);
                thisNode.predCounter();

                if (thisNode.counter == 0)
                {
                    thisNode.delChild(str[i]);
                    return true;
                }
            }
            thisNode.isTerminate = false;
            return true;
        }

        public int howManyPrefix(string str)
        {
            Node node = findNode(str);
            if (node == null)
            {
                return 0;
            }
            return node.counter;
        }
        private int index(char element)
        {
            if (!char.IsLower(element))
            {
                return element - 'A' + 'z' - 'a' + 1;
            }
            return element - 'a';
        }

        private bool checkElemInChild(char element)
        {
            return next[index(element)] != null;
        }

        private Node getChild(char element)
        {
            return next[index(element)];
        }

        private void setChild(char element)
        {
            next[index(element)] = new Node();
        }

        private void delChild(char element)
        {
            next[index(element)] = null;
        }

        private void succCounter()
        {
            counter++;
        }

        private void predCounter()
        {
            counter--;
        }

        private Node findNode(string str)
        {
            Node thisNode = this;
            for (int i = 0; i < str.Length && thisNode != null; i++)
            {
                thisNode = thisNode.getChild(str[i]);
            }
            return thisNode;
        }

    }
}