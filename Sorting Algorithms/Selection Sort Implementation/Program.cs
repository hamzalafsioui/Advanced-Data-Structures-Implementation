namespace Selection_Sort_Implementation
{
	public class SelectionSortExample
	{

		/// <summary>
		/// sorts <paramref name="array"/> using Selection Sort By Ordering (Asc or Desc)
		/// </summary>
		/// <param name="array">array that will be sorted</param>
		/// <param name="Asc">Bool Value of Ordering</param>
		static public void SelectionSort(int[] array, bool Asc = true)
		{
			if (array is null)
				return;

			int MinIndex, MinValue, temp;
			for (int i = 0; i < array.Length - 1; i++)
			{
				MinIndex = i;
				for (int j = i + 1; j < array.Length; j++)
				{
					if (Asc ? (array[j] < array[MinIndex]) : (array[j] > array[MinIndex]))
						MinIndex = j;

				}
				// swap the values
				temp = array[i];
				array[i] = array[MinIndex];
				array[MinIndex] = temp;
			}

		}

		static void Main(string[] args)
		{
			Console.WriteLine("Original Array: ");
			int[] elements = { 12, 26, 8, 23, 74, 68, 91, 43 };
			foreach (int element in elements) Console.Write(element + " ");

			Console.WriteLine();
			SelectionSort(elements);
			Console.WriteLine("\nSorting Asc: ");
			foreach (int element in elements) Console.Write(element + " ");

			SelectionSort(elements, false);
			Console.WriteLine("\nSorting Desc: ");
			foreach (int element in elements) Console.Write(element + " ");

		}
	}
}
