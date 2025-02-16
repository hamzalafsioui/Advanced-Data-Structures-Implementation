

namespace AVL_Tree_Implementation;

internal class Program
{

	class AVLNode
	{
		public int Value { get; set; }
		public AVLNode Right { get; set; }
		public AVLNode Left { get; set; }
		public int Height { get; set; }
		public AVLNode(int value)
		{
			Value = value;
			Height = 1;
		}
	}
	class AVLTree
	{
		private AVLNode root;

		public void Insert(int value)
		{
			root = Insert(root, value);
		}

		private AVLNode Insert(AVLNode node, int value)
		{
			if (node == null)
				return new AVLNode(value);

			if (value < node.Value)
				node.Left = Insert(node.Right, value);
			else if (value > node.Value)
				node.Right = Insert(node.Right, value);
			else
				return node;

			UpdateHeight(node);
		}

		private void UpdateHeight(AVLNode root)
		{
			throw new NotImplementedException();
		}
	}



	static void Main(string[] args)
	{

	}
}
