using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
        public TreeNode(int value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
        }

        public TreeNode()
        {
            Value = default(int);
            LeftChild = null;
            RightChild = null;
        }

        public TreeNode(int value, TreeNode lChild, TreeNode rChild)
        {
            Value = value;
            LeftChild = lChild;
            RightChild = rChild;
        }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public class Tree : ITree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }

        public Tree()
        {
            root = null;
        }

        public Tree(int value)
        {
            TreeNode p = new TreeNode(value);
            root = p;
        }
        public void AddItem(int value)
        {
            throw new NotImplementedException();
        }

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode iterator = root;

            while (iterator != null)
            {
                int compare = value - iterator.Value;
                if (value == iterator.Value)
                    return iterator;

                if (compare < 0)
                {
                    iterator = iterator.LeftChild;
                    continue;
                }
                iterator = iterator.RightChild;
            }
            return null;
        }

        public TreeNode GetRoot()
        {
            return root;
        }

        public void PrintTree()
        {
            NodeInfo[] nodes = TreeHelper.GetTreeInLine(this);
            int level = 0;
            int XCurcor = Console.WindowWidth / 2;
            int YCursor = Console.CursorTop;
            int paddingSize = 0;
            int nodeTextLength = 0;            
            for (int i = 0; i < nodes.Length; i++)
            {
                Console.SetCursorPosition(XCurcor, YCursor);
                paddingSize = nodes[nodes.Length - 1].Depth - level;
                nodeTextLength = nodes[i].Node.Value.ToString().Length + 2;
                if (level != nodes[i].Depth)
                {
                    XCurcor = Console.CursorLeft - 3;
                    YCursor = Console.CursorTop + 1;
                    Console.WriteLine();
                    Console.SetCursorPosition(XCurcor, YCursor);
                    Console.Write("[{0}]", nodes[i].Node.Value);
                }
                else
                {
                    Console.Write("[{0}]", nodes[i].Node.Value);                    
                    XCurcor = Console.CursorLeft;
                    YCursor = Console.CursorTop;
                    if (nodes[i].Node.RightChild != null)
                    {                        
                        Console.Write(new string('_', paddingSize));
                        Console.WriteLine();
                        Console.SetCursorPosition(XCurcor + paddingSize, Console.CursorTop);
                        Console.Write('\\');
                        XCurcor = Console.CursorLeft -1 ;
                        YCursor = Console.CursorTop + 1;
                        Console.WriteLine();
                        Console.SetCursorPosition(XCurcor, YCursor);
                        Console.Write("[{0}]", nodes[i].Node.RightChild.Value);
                        XCurcor = Console.CursorLeft - paddingSize - nodeTextLength;
                        YCursor = Console.CursorTop - 2;
                        Console.SetCursorPosition(XCurcor, YCursor);
                    }
                    if (nodes[i].Node.LeftChild != null)
                    {
                        Console.SetCursorPosition(XCurcor - (paddingSize + nodeTextLength), YCursor);
                        Console.Write(new string('_', nodes[nodes.Length - 1].Depth - level));
                        Console.WriteLine();
                        Console.SetCursorPosition(XCurcor - (paddingSize + nodeTextLength + 1), Console.CursorTop);
                        Console.Write('/');
                        XCurcor = Console.CursorLeft-3;
                        YCursor = Console.CursorTop+1;
                        Console.WriteLine();
                        Console.SetCursorPosition(XCurcor, YCursor);
                        Console.Write("[{0}]", nodes[i].Node.LeftChild.Value);
                        XCurcor = Console.CursorLeft + paddingSize + nodeTextLength;
                        YCursor = Console.CursorTop - 2;
                        Console.SetCursorPosition(XCurcor, YCursor);
                    }
                }
                level = nodes[i].Depth;
            }
        }

        public void RemoveItem(int value)
        {
            throw new NotImplementedException();
        }
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }

}
