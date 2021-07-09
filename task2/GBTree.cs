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

        public TreeNode Parent { get; set; }

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

        public List<TreeNode> Children
        {
            get
            {
                List<TreeNode> res = new List<TreeNode>();
                if (LeftChild != null)
                    res.Add(LeftChild);
                if (RightChild != null)
                    res.Add(RightChild);
                return res;
            }
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
            TreeNode tmp = root;
            TreeNode par = tmp;

            while (tmp != null)
            {
                par = tmp;
                if (tmp.Value.CompareTo(value) == 0)
                {
                    Console.WriteLine($"Элемент {value} уже записан\n");
                    return;
                }
                else if (tmp.Value.CompareTo(value) > 0)
                    tmp = tmp.LeftChild;
                else
                    tmp = tmp.RightChild;
            }

            tmp = new TreeNode(value);

            if (par == null)
            {
                tmp.Parent = tmp;
                root = tmp;
            }
            else
            {
                tmp.Parent = par;
                if (value.CompareTo(par.Value) < 0)
                    par.LeftChild = tmp;
                else
                    par.RightChild = tmp;
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            if (root == null)
                return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();                
                if (value == node.Value)
                    return node;
                if (node.LeftChild != null)
                    queue.Enqueue(node.LeftChild);

                if (node.RightChild != null)
                    queue.Enqueue(node.RightChild);
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

        public void PrintTree(TreeNode node, int indentSize, int currentLevel)
        {
            var currentNode = string.Format("{0}{1}", new string(' ', indentSize * currentLevel), node.Value);
            Console.WriteLine(currentNode);
            foreach (var child in node.Children)
            {
                PrintTree(child, indentSize, currentLevel + 1);
            }
        }

        public void Print(TreeNode node, string result)
        {
            if (node.Children == null || node.Children.Count == 0)
            {                
                Console.WriteLine(result);
                return;
            }
            foreach (var child in node.Children)
            {
                Print(child, result + " " + child.Value.ToString());
            }
        }

        public void RemoveItem(int value)
        {
            TreeNode nodeToRemove = GetNodeByValue(value);
            if (nodeToRemove == null)
                return;

            if (nodeToRemove.LeftChild == null && nodeToRemove.RightChild == null)
            {                
                if (nodeToRemove == root)
                    root = null;
                else
                {
                    TreeNode par = nodeToRemove.Parent;
                    if (par.LeftChild == nodeToRemove)
                        par.LeftChild = null;
                    else
                        par.RightChild = null;
                }                
            }
            else if (nodeToRemove.LeftChild == null || nodeToRemove.RightChild == null)
            {                
                bool isroot = nodeToRemove == root;

                var par = nodeToRemove.Parent;
                var newchild = nodeToRemove.LeftChild ?? nodeToRemove.RightChild;
                newchild.Parent = par;
                if (par.LeftChild == nodeToRemove)
                    par.LeftChild = newchild;
                else
                    par.RightChild = newchild;

                if (isroot)
                    root = newchild;               
            }
            else
            {                
                TreeNode repl = Max(nodeToRemove.LeftChild);
                nodeToRemove.Value = repl.Value;
                RemoveItem(repl.Value);                
            }
        }

        private TreeNode Max(TreeNode node)
        {
            TreeNode tmp = node;
            TreeNode ret = node;
            while (tmp != null)
            {
                ret = tmp;
                tmp = tmp.RightChild;
            }
            return ret;
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
