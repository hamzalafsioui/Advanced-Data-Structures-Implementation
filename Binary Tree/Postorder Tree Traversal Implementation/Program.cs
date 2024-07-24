
namespace Postorder_Tree_Traversal_Implementation
{
	public class Program
	{
		public class BinaryTreeNode<T>
		{
			public T value { get; set; }
			public BinaryTreeNode<T> Right { get; set; }
			public BinaryTreeNode<T> Left { get; set; }
			public BinaryTreeNode(T value)
			{
				this.value = value;
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

			private void PrintTree(BinaryTreeNode<T> root, int space)
			{
				int Count = 10;
				space += Count;
				if (root == null)
				{
					return;
				}
				Console.WriteLine();
				PrintTree(root.Right, space);

				for (int i = Count; i < space; i++)
					Console.Write(" ");

				Console.WriteLine(root.value);

				PrintTree(root.Left, space);
			}
			private void PreOrderTraversal(BinaryTreeNode<T> node)
			{
				/*
	              PreOrder Traversal visits the current node before its child nodes.
	              The process for PreOrder Traversal is as follows:


	                 - Visit the current node.
	                 - Recursively perform PreOrder Traversal of the left subtree.
	                 - Recursively perform PreOrder Traversal of the right subtree.
	            */

				if (node != null)
				{
					Console.Write(node.value + " ");
					PreOrderTraversal(node.Left);
					PreOrderTraversal(node.Right);
				}



			}
			public void PreOrderTraversal()
			{
				PreOrderTraversal(Root);

			}

			private void PostOrderTraversal(BinaryTreeNode<T> node)
			{

				/*
	              PostOrder Traversal visits the current node after its child nodes.
	              The process for PostOrder Traversal is:


	                - Recursively perform PostOrder Traversal of the left subtree.
	                - Recursively perform PostOrder Traversal of the right subtree.
	                - Visit the current node.
	           */
				if (node != null)
				{
					PostOrderTraversal(node.Left);
					PostOrderTraversal(node.Right);
					Console.Write(node.value + " ");
				}
			}
			public void PostOrderTraversal()
			{
				PostOrderTraversal(Root);
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

			Console.Write("\n\nPreOrder Traversal:  ");
			binaryTree.PreOrderTraversal();

			Console.Write("\n\nPostOrder Traversal: ");
			binaryTree.PostOrderTraversal();

			Console.ReadKey();
		}
	}
}
