using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Demo
    {
        static void Main(string[] args)
        {
            
            BT<int> bt = new BT<int>();
            foreach (int i in new int[] { 5, 2, 8, 1, 3, 4, 6, 9, 7, 10, 10 })
            {
                bt.addNode(i);
                Console.WriteLine("{0}  added", i);
                bt.inOrderTraverse();
            }
            
            foreach (int i in new[] { 9, 10, 66, 8 })
            {
                if (bt.delete(i))
                {
                    Console.WriteLine("{0}  deleted",i);
                    bt.inOrderTraverse();
                }
                else
                {
                    Console.WriteLine("{0}  not found", i);
                    bt.inOrderTraverse();
                }
            }

            Console.Write("\n\npre order Traverse   :");
            bt.preOrderTraverse();
            Console.Write("in order Traverse   :");
            bt.inOrderTraverse();
            Console.Write("post order Traverse   :");
            bt.postOrderTraverse();


            Node<int> target;
            if (bt.search(6, out target))
            {
                Console.WriteLine("{0}  found", target.Value);
            }
            else { Console.WriteLine("target not found"); }

        }
        

    }
}
