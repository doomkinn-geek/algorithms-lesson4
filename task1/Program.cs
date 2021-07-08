using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree(50);
            tree.Root.Left = new Node(22);
            tree.Root.Right = new Node(25);
            tree.Root.Left.Left = new Node(28, new Node(64), new Node(34));
            tree.Root.Left.Right = new Node(11);
            tree.Root.Right.Left = new Node(5, new Node(67), new Node(46));
            tree.Root.Right.Right = new Node(77);
            tree.Root.Right.Left.Left = new Node(23, new Node(51), new Node(332));
            tree.Root.Right.Left.Right = new Node(13, new Node(22), new Node(99));
            tree.Root.Right.Left.Right.Right = new Node(243, new Node(223), new Node(11));

            Console.WriteLine("Бинарное дерево:");
            Console.WriteLine(new string('=', 40));            
            TreePrinter.Print(tree.Root);
            Console.WriteLine(new string('=', 40));
            

            Console.ReadLine();
        }
    }
}
