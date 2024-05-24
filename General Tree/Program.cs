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


            Console.WriteLine("\n\n======== Family Tree Example: ========\n");
            //Preparing People
            TreeNode<Person> root = new TreeNode<Person>(new Person("Hamza"));
            TreeNode<Person> child1 = new TreeNode<Person>(new Person("Ali"));
            TreeNode<Person> child2 = new TreeNode<Person>(new Person("Ibrahim"));
            TreeNode<Person> child3 = new TreeNode<Person>(new Person("Khaled"));
            TreeNode<Person> child4 = new TreeNode<Person>(new Person("Jamal"));

            TreeNode<Person> grandchild1 = new TreeNode<Person>(new Person("Kamal"));
            TreeNode<Person> grandchild2 = new TreeNode<Person>(new Person("Mohammed"));

            TreeNode<Person> grandchild3 = new TreeNode<Person>(new Person("Yassin"));
            TreeNode<Person> grandchild4 = new TreeNode<Person>(new Person("Tamer"));

            TreeNode<Person> grandchild5 = new TreeNode<Person>(new Person("Rachid"));

            TreeNode<Person> GrandGrandChild1 = new TreeNode<Person>(new Person("Ahmed"));
            // Connecting People 
            child1.Children.Add(grandchild1);
            child1.Children.Add(grandchild2);

            child2.Children.Add(grandchild3);
            child2.Children.Add(grandchild4);

            child3.Children.Add(grandchild5);

            grandchild3.Children.Add(GrandGrandChild1);

            root.Children.Add(child1);
            root.Children.Add(child2);
            root.Children.Add(child3);
            root.Children.Add(child4);

            Person.PrintFamilyTree(root);

            Console.WriteLine("\nPrint Leaf in the family Tree:");
            Person.PrintLeafInFamilyTree(root);


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

    //  Family Tree Example
    public class Person
    {
        public string Name { get; set; }
        // Other properties as age Address ...

        public Person(string name)
        {
            Name = name;
        }

        public static void PrintFamilyTree(TreeNode<Person> node, string indent = "")
        {
            Console.WriteLine(indent + node.Value.Name);

            foreach (var child in node.Children)
            {
                PrintFamilyTree(child, indent + "  ");
            }
        }


        public static void PrintLeafInFamilyTree(TreeNode<Person> node, string indent = " ")
        {
            foreach (var child in node.Children)
            {
                if (child.Children.Count == 0)
                {
                    Console.Write(child.Value.Name + indent);
                }
                PrintLeafInFamilyTree(child);
            }
        }

    }




}
