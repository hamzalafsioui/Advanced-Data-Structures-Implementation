using System;

namespace LinearSearchImplementation
{
	public class LinearSearchExample
	{
		/// <summary>
		/// Searches for element <paramref name="x"/> in array <paramref name="arr"/> using linear search.
		/// </summary>
		/// <param name="arr">The array to search.</param>
		/// <param name="x">The element to find.</param>
		/// <returns>Index of element <paramref name="x"/> if it exists; otherwise, -1.</returns>
		public static int LinearSearch<T>(T[] arr, T x) where T : IEquatable<T>
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i].Equals(x))
				{
					// Return the index of the element if found
					return i;
				}
			}
			// Return -1 if the element is not found
			return -1;
		}

		static void Main(string[] args)
		{
			int[] elements = { 12, 45, 91, 22, 74, 39, 86, 55 }; // Array That Will Be Searched
			Console.Write("Elements: ");
			foreach (var element in elements)
			{
				Console.Write(element + " ");
			}
			Console.WriteLine();

			int item = 39;
			int indexOfItem = LinearSearch(elements, item);

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
