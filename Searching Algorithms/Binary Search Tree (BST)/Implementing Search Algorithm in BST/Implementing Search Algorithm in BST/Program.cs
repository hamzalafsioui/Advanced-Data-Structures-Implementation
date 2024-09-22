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

			var bst = new BinarySearchTree<int>();
			bst.Insert(45);
			bst.Insert(15);
			bst.Insert(79);
			bst.Insert(90);
			bst.Insert(10);
			bst.Insert(55);
			bst.Insert(12);
			bst.Insert(20);
			bst.Insert(50);
			bst.PrintTree();
		}
	}
}
