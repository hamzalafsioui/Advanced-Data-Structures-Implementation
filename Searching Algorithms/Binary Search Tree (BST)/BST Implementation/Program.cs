namespace BST_Implementation
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
		public BinarySearchTreeNode<T> Root { get; set; }
		public BinarySearchTree()
		{
			Root = null;
		}

		public void Insert(T value)
		{
			// If the tree is empty (Root is null), this will assign the new node as the Root.
			// Otherwise, it will call the recursive Insert method to find the correct position for the value.

			Root = Insert(Root, value);
		}

		private BinarySearchTreeNode<T> Insert(BinarySearchTreeNode<T> node, T value)
		{
			// first null is for root after that If we reach a null node, it means this is the correct place to insert the new value.
			if (node == null)
			{
				return new BinarySearchTreeNode<T>(value);
			}
			else if (value.CompareTo(node.Value) > 0)
			{
				node.Right = Insert(node.Right, value); //insert into the right subtree
			}
			else if (value.CompareTo(node.Value) < 0)
			{
				node.Left = Insert(node.Left, value); //insert into the left subtree
			}

			// Return the unchanged node
			return node;
		}

		public void PrintTree()
		{
			PrintTree(Root, 0);
		}

		private void PrintTree(BinarySearchTreeNode<T> root, int space)
		{
			int Count = 10;
			if (root == null)
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
	internal class Program
	{
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
		}
	}
}
