﻿namespace Level_order_Traversal_Implementation
{
	public class Program
	{

		public class BinaryTreeNode<T>
		{
			public T Value { get; set; }
			public BinaryTreeNode<T> Left { get; set; }
			public BinaryTreeNode<T> Right { get; set; }

			public BinaryTreeNode(T value)
			{
				Value = value;
				Left = null!;
				Right = null!;
			}
		}

		public class BinaryTree<T>
		{
			public BinaryTreeNode<T> Root { get; private set; }
			public BinaryTree()
			{
				Root = null!;
			}

			public void Insert(T value)
			{
				var newNode = new BinaryTreeNode<T>(value);
				if (Root == null)
				{
					Root = newNode;
					return;
				}

				Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
				queue.Enqueue(Root);
				while (queue.Count > 0)
				{
					var current = queue.Dequeue();
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

			public void LevelOrderTraversal()
			{
				if (Root == null) return;

				Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
				queue.Enqueue(Root);

				while (queue.Count > 0)
				{
					var current = queue.Dequeue();
					Console.Write(current.Value + " ");
					if (current.Left != null)
						queue.Enqueue(current.Left);

					if (current.Right != null)
						queue.Enqueue(current.Right);
				}

			}

			/// <summary>
			/// Retrieve or return all nodes at specific <paramref name="level"/>
			/// </summary>
			/// <param name="level"></param>
			/// <returns>return all nodes at level</returns>
			public List<T> GetNodesAtLevel(int level)
			{
				List<T> result = new List<T>();
				if (Root == null || level < 0)
					return result;

				Queue<BinaryTreeNode<T>> nodeQueue = new Queue<BinaryTreeNode<T>>();
				Queue<int> levelQueue = new Queue<int>();

				nodeQueue.Enqueue(Root);
				levelQueue.Enqueue(0);

				while (nodeQueue.Count > 0)
				{
					var currentNode = nodeQueue.Dequeue();
					var currentLevel = levelQueue.Dequeue();

					if (currentLevel == level)
					{
						result.Add(currentNode.Value);
					}

					if (currentNode.Left != null)
					{
						// in this step We enqueue the left node with the same level
						nodeQueue.Enqueue(currentNode.Left); 
						levelQueue.Enqueue(currentLevel + 1);
					}

					if (currentNode.Right != null)
					{
						// in this step We enqueue the right node with the same level
						nodeQueue.Enqueue(currentNode.Right);
						levelQueue.Enqueue(currentLevel + 1);
					}
				}

				return result;
			}

			public void PrintTree()
			{
				PrintTree(Root, 0);
			}

			private void PrintTree(BinaryTreeNode<T> root, int space)
			{
				int Count = 10; // distance between levels
				if (root == null) return;
				space += Count;

				PrintTree(root.Right, space); // Right Nodes Processing
				Console.WriteLine();
				for (int i = Count; i < space; i++)
					Console.Write(" ");

				Console.WriteLine(root.Value); // print value of root

				PrintTree(root.Left, space); // Left Nodes Processing

			}
		}


		static void Main(string[] args)
		{
			var binaryTree = new BinaryTree<int>();
			Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9\n");

			binaryTree.Insert(5);
			binaryTree.Insert(3);
			binaryTree.Insert(8);
			binaryTree.Insert(1);
			binaryTree.Insert(4);
			binaryTree.Insert(6);
			binaryTree.Insert(9);

			binaryTree.PrintTree();

			Console.WriteLine("\nLevel Order Traversal: ");
			binaryTree.LevelOrderTraversal();

			Console.WriteLine("\nEnter the level you want to retrieve:");
			int level = int.Parse(Console.ReadLine()!);

			List<int> nodesAtLevel = binaryTree.GetNodesAtLevel(level);

			Console.WriteLine($"Nodes at level {level}: {string.Join(", ", nodesAtLevel)}");

		}
	}
}
