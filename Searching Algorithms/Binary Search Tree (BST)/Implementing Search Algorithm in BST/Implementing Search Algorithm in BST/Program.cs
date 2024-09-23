namespace Implementing_Search_Algorithm_in_BST
{
	public class Program
	{

		public class BinarySearchTreeNode<T> where T : IComparable<T>
		{
			public T Value { get; set; }
			public BinarySearchTreeNode<T> Left { get; set; }
			public BinarySearchTreeNode<T> Right { get; set; }
			public BinarySearchTreeNode(T value)
			{
				Value = value;
				Left = null;
				Right = null;
			}


		}

		public class BinarySearchTree<T> where T : IComparable<T>
		{
			public BinarySearchTreeNode<T> Root { get; private set; }
			public BinarySearchTree()
			{
				Root = null;
			}

			public void Insert(T value)
			{
				Root = Insert(Root, value);
			}

			private BinarySearchTreeNode<T> Insert(BinarySearchTreeNode<T> root, T value)
			{
				if (root == null)
					return new BinarySearchTreeNode<T>(value);

				else if (root.Value.CompareTo(value) > 0)
					root.Left = Insert(root.Left, value);

				else if (root.Value.CompareTo(value) < 0)
					root.Right = Insert(root.Right, value);

				return root;
			}

			public bool Search(T value)
			{
				return Search(Root, value);
			}
			public bool Search(BinarySearchTreeNode<T> root, T value)
			{
				if (root == null)
					return false;
				if (root.Value.CompareTo(value) == 0)
					return true;

				if (root.Value.CompareTo(value) < 0)
					return Search(root.Right, value);

				else if (root.Value.CompareTo(value) > 0)
					return Search(root.Left, value);

				return false;
			}

			public int GetLevelOfValue(T value)
			{
				int level = 0;
				if (Root == null)
					return -1;
				Queue<BinarySearchTreeNode<T>> queue = new Queue<BinarySearchTreeNode<T>>();
				queue.Enqueue(Root);
				while (queue.Count > 0)
				{
					var currentNode = queue.Dequeue();
					if (currentNode.Value.CompareTo(value) == 0)
						return level;

					else if (currentNode.Value.CompareTo(value) < 0 && currentNode.Right != null)
					{
						queue.Enqueue(currentNode.Right);
						level++;
					}
					else if (currentNode.Value.CompareTo(value) > 0 && currentNode.Left != null)
					{
						queue.Enqueue(currentNode.Left);
						level++;
					}
				}
				return -1;
			}


			public void PrintTree()
			{
				PrintTree(Root, 0);
			}

			private void PrintTree(BinarySearchTreeNode<T> root, int space)
			{
				int Count = 10;
				if (root is null)
					return;
				space += Count;
				PrintTree(root.Right, space);
				Console.WriteLine();
				for (int i = Count; i < space; i++)
				{
					Console.Write(" ");
				}
				Console.WriteLine(root.Value);

				PrintTree(root.Left, space);
			}
		}

		static void Main(string[] args)
		{
			Console.WriteLine("\nInserting : 45, 15, 79, 90, 10, 55, 12, 20, 50\r\n");

			var BST = new BinarySearchTree<int>();
			BST.Insert(45);
			BST.Insert(15);
			BST.Insert(79);
			BST.Insert(90);
			BST.Insert(10);
			BST.Insert(55);
			BST.Insert(12);
			BST.Insert(20);
			BST.Insert(50);
			BST.PrintTree();

			Console.WriteLine($"Is Value 90 Exist ? {BST.Search(90)} In Level {BST.GetLevelOfValue(90)}");
			Console.WriteLine($"Is Value 34 Exist ? {BST.Search(34)} In Level {BST.GetLevelOfValue(34)}");
		}
	}
}
