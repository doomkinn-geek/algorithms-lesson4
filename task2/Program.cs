using System;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Tree gbtree = new Tree(50);
            gbtree.Root.LeftChild = new TreeNode(22);
            gbtree.Root.RightChild = new TreeNode(25);
            gbtree.Root.LeftChild.LeftChild = new TreeNode(28, new TreeNode(64), new TreeNode(34));
            gbtree.Root.LeftChild.RightChild = new TreeNode(11);
            gbtree.Root.RightChild.LeftChild = new TreeNode(5, new TreeNode(67), new TreeNode(46));
            gbtree.Root.RightChild.RightChild = new TreeNode(77);
            gbtree.Root.RightChild.LeftChild.LeftChild = new TreeNode(23, new TreeNode(51), new TreeNode(332));
            gbtree.Root.RightChild.LeftChild.RightChild = new TreeNode(13, new TreeNode(22), new TreeNode(99));
            gbtree.Root.RightChild.LeftChild.RightChild.RightChild = new TreeNode(243, new TreeNode(223), new TreeNode(11));


            Console.Write("Бинарное дерево ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("(бился над печатью дерева, так и не смог сделать самостоятельно)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', 60));            
            TreePrinter.Print(gbtree.Root);
            Console.WriteLine(new string('=', 60));
            TreePrinter.Print(gbtree.GetNodeByValue(25));
            Console.WriteLine(new string('=', 60));
            TreePrinter.Print(gbtree.GetNodeByValue(5));
            Console.WriteLine(new string('=', 60));

            Tree gbtree2 = new Tree(45);
            List<int> ls = new List<int> { 23, 51, 28, 1, 62, 67, 221, 91, 26,11,29,36,72 };
            foreach (int i in ls)
                gbtree2.AddItem(i);

            TreePrinter.Print(gbtree2.Root);
            gbtree2.RemoveItem(91);
            TreePrinter.Print(gbtree2.Root);            

            Console.ReadLine();
        }
    }
}
