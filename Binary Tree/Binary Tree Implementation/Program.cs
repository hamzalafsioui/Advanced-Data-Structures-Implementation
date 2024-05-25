using System;
using System.Collections.Generic;

namespace Binary_Tree_Implementation
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }                // The Value Stored in The Node
        public BinaryTreeNode<T> Left { get; set; }  // Reference to the Left Child
        public BinaryTreeNode<T> Right { get; set; } // Reference to the Right Child
        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; } // the Root node of the tree

        // Constructor to Initializing an empty tree
        public BinaryTree()
        {
            Root = null;
        }

        // Method to insert a new value into the tree
        public void Insert(T value)
        {


            /*
             We use Level-order insertion strategy,
             Level-order insertion: in a binary tree is a strategy that fills the tree level by level,
             from left to right. This approach ensures that every level of the tree is completely
             filled before any nodes are added to a new level,
             and each parent node has at most two children before moving on to the next node in the
             sequence.

             */
            var newNode = new BinaryTreeNode<T>(value); // Create a new node
            if (Root == null)
            {
                Root = newNode; // if the tree is empty, set the newNode as the Root
                return;
            }

            // Use queue to perform level-Order insertion
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                // Attempt to insert the new node in the first empty spot in level order
                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }

            }
        }
        // Method to visually print the tree structure
        public void PrintTree()
        {
            PrintTree(Root, 0);
        }

        private void PrintTree(BinaryTreeNode<T> root, int Space)
        {
            int Count = 10; // Distance between levels to adjust the visual representation

            if (root == null)
                return;
            Space += Count;
            PrintTree(root.Right, Space); // Print right subtree first, then root, and left subtree last
            Console.WriteLine();
            for (int i = Count; i < Space; i++)
                Console.Write(" ");

            Console.WriteLine(root.Value);// Print the current node after space

            PrintTree(root.Left, Space); // Recur on the left child



        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 5,3,8,1,2,7,9\n");

            binaryTree.Insert(5);
            binaryTree.Insert(3);
            binaryTree.Insert(8);
            binaryTree.Insert(1);
            binaryTree.Insert(2);
            binaryTree.Insert(7);
            binaryTree.Insert(9);

            binaryTree.PrintTree();

            Console.ReadKey();

        }

    }
}
