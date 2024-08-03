namespace Binary_Search_Implementation
{
	public class BinarySearchExample
	{

		/// <summary>
		/// searches for an <paramref name="element"/> in <paramref name="array"/> using Binary Search
		/// </summary>
		/// <param name="array">the array to search</param>
		/// <param name="element">the element to find</param>
		/// <returns>Index of element if exists,otherwise, -1</returns>
		static public int BinarySearch(int[] array, int element)
		{
			int start = 0;
			int End = array.Length - 1;


			while (start <= End)
			{
				int Middle = start + (End - start) / 2;

				if (array[Middle] == element)
					return Middle;

				if (array[Middle] > element)
				{
					End = Middle - 1;
				}
				else
				{
					start = Middle + 1;
				}

			}




			return -1;
		}
		static void Main(string[] args)
		{

			int[] elements = { 12, 19, 20, 22, 74, 81, 86, 95 }; // Array That Will Be Searched and already sorted
			Console.Write("Elements: ");
			foreach (var element in elements)
			{
				Console.Write(element + " ");
			}
			Console.WriteLine();

			int item = 81; // element to be searched
			int indexOfItem = BinarySearch(elements, item);

			if (indexOfItem != -1)
			{
				Console.WriteLine($"Item {item} is found at index {indexOfItem}.");
			}
			else
			{
				Console.WriteLine("Item does not exist in the array.");
			}

			Console.ReadKey();
		}
	}
}
