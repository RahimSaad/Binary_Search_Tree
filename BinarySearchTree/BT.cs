using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BT<T> where T : IComparable
    {
        Node<T> Root;
        private int size;
        public int Size { get => size; }
        public int Depth {get => Root.Depth; }
        public BT()
        {
              
        }

        public void addNode(T value)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(value);
            }
            else
            {
                addNodeIteratively(value, this.Root);
            }
            size++;
        }

        private void addNodeIteratively(T value, Node<T> root)
        {
            bool done = false;
            while (!done)
            {
                if (value.CompareTo(root.Value) < 0)
                {
                    if (root.Left == null)
                    {
                        root.Left = new Node<T>(value);
                        done = true;
                    }
                    root = root.Left;
                }
                else
                {
                    if (root.Right == null)
                    {
                        root.Right = new Node<T>(value);
                        done = true;
                    }
                    root = root.Right;
                }
            }
        }
        
        public bool search(T value, out Node<T> item)
        {
            item = null;
            bool found = false; 
            Node<T> rf = this.Root;
            while (!found && (rf != null))
            {
                if (value.CompareTo(rf.Value) == 0)
                {
                    found = true;
                    item = rf;
                }
                else if (value.CompareTo(rf.Value) < 0)
                {
                    rf = rf.Left;
                }
                else
                {
                    rf = rf.Right;
                }
            }
            return found;
        }
        
        public bool delete(T value)
        {
            Node<T> parent = null, child = this.Root;
            while (child != null)
            {
                if (value.CompareTo(child.Value) == 0) 
                {
                    if(parent == null) // incase of deleting the root
                    {
                        deleteNode(ref this.Root);
                    } 
                    else if (value.CompareTo(parent.Value) < 0)
                    {
                        deleteNode(ref parent.Left);
                    }
                    else
                    {
                        deleteNode(ref parent.Right);
                    }
                    size--;
                    return true;
                }
                else if (value.CompareTo(child.Value) < 0)
                {
                    parent = child;
                    child = child.Left;
                }
                else
                {
                    parent = child;
                    child = child.Right;
                }
            }
            return false;
        }

        private void deleteNode(ref Node<T> node)
        {
            if (node.Left == null)
            {
                node = node.Right; // if the node.Right == null then it's okay , the node will be deleted as well 
            }
            else if (node.Right == null) // given node.Left != null
            {
                node = node.Left;
            }
            else // given (node.Left != null && node.Right != null)
            {
                // get the node with the greatest value on the left and substitute its value with the value of node to be deleted
                Node<T> parent, child = node.Left;
                if (child.Right == null) // then the (node.left) which is the child right now is the greatest on the left 
                {
                    node.Value = child.Value;
                    node.Left = child.Left; // if the child.Left is null it's okay as well
                }
                else
                {
                    do
                    {
                        parent = child;
                        child = child.Right;
                    } while (child.Right != null);
                    node.Value = child.Value;
                    parent.Right = child.Left; // if the child hold nothing in its left it's okay as well
                }
            }
        }

        public void preOrderTraverse()
        {
            preOrderTraverse(this.Root);
            Console.Write("    size = {0}  depth = {1}\n", this.Size, this.Depth);
        }

        public void inOrderTraverse()
        {
            inOrderTraverse(this.Root);
            Console.Write("    size = {0}  depth = {1}\n", this.Size, this.Depth);
        }

        public void postOrderTraverse()
        {
            postOrderTraverse(this.Root);
            Console.Write("    size = {0}  depth = {1}\n", this.Size, this.Depth);
        }
        
        private void preOrderTraverse(Node<T> root)
        {
            Console.Write("  {0}  ", root.Value);
            if (root.Left != null) { preOrderTraverse(root.Left); }
            if (root.Right != null) { preOrderTraverse(root.Right); }
        }

        private void inOrderTraverse(Node<T> root)
        {
            if (root.Left != null) { inOrderTraverse(root.Left); }
            Console.Write("  {0}  ", root.Value);
            if (root.Right != null) { inOrderTraverse(root.Right); }
        }
        
        private void postOrderTraverse(Node<T> root)
        {
            if (root.Left != null) { postOrderTraverse(root.Left); }
            if (root.Right != null) { postOrderTraverse(root.Right); }
            Console.Write("  {0}  ", root.Value);
        }

        // it is not advisable to use recursive adding because it waste time and memory through pushing data to the call stack 
        // , use iterative adding instead
        //private void addNodeRecursively(T value , Node<T> root)
        //{
        //    if (value.CompareTo(root.Value) < 0)
        //    {
        //        if(root.Left == null)
        //        {
        //            root.Left = new Node<T>(value);
        //        }
        //        else
        //        {
        //            addNodeRecursively(value, root.Left);
        //        }
        //    }
        //    else
        //    {
        //        if (root.Right == null)
        //        {
        //            root.Right = new Node<T>(value);
        //        }
        //        else
        //        {
        //            addNodeRecursively(value, root.Right);
        //        }
        //    }
        //}

    }
}
