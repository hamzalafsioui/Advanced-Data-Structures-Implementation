
namespace Preorder_Tree_Traversal_Implementation
{
	internal class Program
	{
		public class BinaryTreeNode<T>
		{
			public T Value { get; set; }
			public BinaryTreeNode<T> Left { get; set; }
			public BinaryTreeNode<T> Right { get; set; }

			public BinaryTreeNode(T value)
			{
				Value = value;
				Left = null;
				Right = null;
			}
		}

		public class BinaryTree<T>
		{
			public BinaryTreeNode<T> Root { get; private set; }

			public BinaryTree()
			{
				Root = null;
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

			public void PrintTree()
			{
				PrintTree(Root, 0);
			}

			public void PrintTree(BinaryTreeNode<T> root, int space)
			{
				int Count = 10; // Distance Between Levels
				if (root == null)
					return;

				space += Count; // Increase Space

				PrintTree(root.Right, space); // Print First Right
				Console.WriteLine();



				for (int i = Count; i < space; i++)
					Console.Write(" ");

				Console.WriteLine(root.Value); // print value of Current root after reached null value (return) of The next of this root


				PrintTree(root.Left, space); // Print Second Left
			}
		}


		static void Main(string[] args)
		{
			var BinaryTree = new BinaryTree<int>();
			Console.WriteLine("Value to be inserted: 5,3,9,6,4,1,8\n");

			BinaryTree.Insert(5);
			BinaryTree.Insert(3);
			BinaryTree.Insert(9);
			BinaryTree.Insert(6);
			BinaryTree.Insert(4);
			BinaryTree.Insert(1);
			BinaryTree.Insert(8);

			BinaryTree.PrintTree();
		}
	}
}
