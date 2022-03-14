using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Node<T>
    {
        public Node<T> Left;
        public Node<T> Right;
        public T Value;
        public int Depth { get => getDepth(this); }

        private int getDepth(Node<T> node)
        {
            return (node == null) ? -1 : Math.Max(getDepth(node.Left), getDepth(node.Right)) + 1;
        }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
