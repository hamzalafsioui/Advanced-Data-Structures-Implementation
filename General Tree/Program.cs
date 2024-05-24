using System;
using System.Collections.Generic;

namespace General_Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }
        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

    }
    public class Tree<T>
    {
        public TreeNode<T> Root { get; private set; }
        public Tree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var companyTree = new Tree<string>("CEO");
            var finance = new TreeNode<string>("CFO");
            var tech = new TreeNode<string>("CTO");
            var marketing = new TreeNode<string>("CMO");

            // Add departments to CEO
            companyTree.Root.AddChild(finance);
            companyTree.Root.AddChild(tech);
            companyTree.Root.AddChild(marketing);

            // Add employees to departments
            finance.AddChild(new TreeNode<string>("Accountant"));
            tech.AddChild(new TreeNode<string>("Developer"));
            tech.AddChild(new TreeNode<string>("UX Designer"));
            marketing.AddChild(new TreeNode<string>("Social Media Manager"));

            // Printing the tree
            PrintTree(companyTree.Root);

            Console.ReadLine();
        }
        public static void PrintTree<T>(TreeNode<T> node, string indent = " ")
        {
            Console.WriteLine(indent + node.Value);
            foreach (var child in node.Children)
            {
                PrintTree(child, indent + " ");
            }
        }
    }

}
