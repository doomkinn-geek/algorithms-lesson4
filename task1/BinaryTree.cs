using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    public class Node
    {
        int data;
        Node left;
        Node right;

        public Node(int value)
        {
            data = value;
            left = null;
            right = null;
        }

        public Node()
        {
            data = default(int);
            left = null;
            right = null;
        }

        public Node(int value, Node lChild, Node rChild)
        {
            data = value;
            left = lChild;
            right = rChild;
        }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }

        public Node Right
        {
            get { return right; }
            set { right = value; }
        }
    }

    class BinaryTree
    {
        private Node root;
        public Node Root
        {
            get { return root; }
        }

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(int value)
        {
            Node p = new Node(value);
            root = p;
        }

        public bool Find(int value)
        {
            Node iterator = root;

            while (iterator != null)
            {
                int compare = value - iterator.Data;
                if (value == iterator.Data)
                    return true;

                if (compare < 0)
                {
                    iterator = iterator.Left;
                    continue;
                }
                iterator = iterator.Right;
            }
            return false;
        }

        public void Print()
        {
            Print(root, 4);
        }

        public void Print(Node p, int padding)
        {
            if (p != null)
            {
                if (p.Right != null)
                {
                    Print(p.Right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.Data.ToString() + "\n ");
                if (p.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.Left, padding + 4);
                }
            }
        }

        public void NewPrint(Node p, int pad, int left)
        {
            if(p != null)
            {
                return;
            }
        }

        

        /*private static void Print(Node item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }*/

        private static void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        private static void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    }
}
