namespace Bubble_Sort_Implementation
{
	public class BubbleSortExample
	{

		/// <summary>
		/// Sorts <paramref name="array"/> By Using Bubble Sort
		/// </summary>
		/// <param name="array">array that will be sorting</param>
		static public void BubbleSort(int[] array)
		{
			int length = array.Length;
			for (int i = 0; i < length; i++)
			{
				// length - i - 1 , we use -1 to avoid Exception in (j+1) and we reduce the value of i to avoid largest value correctly placed at the button
				for (int j = 0; j < length - i - 1; j++)
				{
					int temp;
					if (array[j] > array[j + 1])
					{
						// temp array to swap 
						temp = array[j];
						array[j] = array[j + 1];
						array[j + 1] = temp;
					}
				}

			}
		}

		static void Main(string[] args)
		{
			int[] elements = { 12, 8, 91, 36, 42, 37, 78 };
			Console.WriteLine("Original Array: ");
			foreach (int element in elements) Console.Write(element + " ");

			BubbleSort(elements);
			Console.WriteLine("\nArray after Sorting: ");
			foreach (int element in elements) Console.Write(element + " ");


			Console.ReadKey();
		}
	}
}
