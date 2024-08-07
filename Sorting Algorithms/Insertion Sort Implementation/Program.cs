
namespace Insertion_Sort_Implementation
{
	internal class InsertionSortExample
	{

		/// <summary>
		/// Sorts <paramref name="numbers"/> by using Insertion Sort
		/// </summary>
		/// <param name="numbers">array that will be Sorting</param>
		static public void InsertionSort(int[] numbers)
		{
			if (numbers == null || numbers.Length == 1)
				return;

			for (int i = 0; i < numbers.Length; i++)
			{
				int key = numbers[i];
				int j = i - 1;
				while (j >= 0 && key < numbers[j])
				{
					numbers[j + 1] = numbers[j];  // in the first iteration numbers[j+1]  will be equal numbers[i]
					j--;
				}
				numbers[j + 1] = key;
			}

		}

		/// <summary>
		/// Sorts <paramref name="numbers"/> by using Insertion Sort
		/// </summary>
		/// <param name="numbers">array that will be Sorting</param>
		static public void InsertionSortV1(int[] numbers)
		{
			if (numbers == null || numbers.Length == 1)
				return;

			for (int i = 0; i < numbers.Length; i++)
			{
				int key = numbers[i];
				int RightPosition = FindRightPosition(numbers.Take(i + 1), key);
				if (RightPosition != -1)
				{
					for (int j = i; j > RightPosition; j--)  // This for loop is using to swap numbers from the current element to right Position 
					{
						numbers[j] = numbers[j - 1];
					}
					numbers[RightPosition] = key;
				}
			}

		}

		private static int FindRightPosition(IEnumerable<int> enumerable, int value)
		{
			if (enumerable == null)
				return -1;
			int Index = -1;
			foreach (int item in enumerable)
			{
				Index++;
				if (item >= value)
					return Index;

			}
			return Index;
		}

		static void Main(string[] args)
		{
			int[] numbers = { 12, 3, 7, 4, 9, 10, 8, 44, 29, 71 };
			Console.WriteLine("Original Array: ");
			foreach (int item in numbers) Console.Write(item.ToString("D2") + " ");
			Console.WriteLine();
			InsertionSort(numbers);
			foreach (int item in numbers) Console.Write(item.ToString("D2") + " ");


			int[] numbersV1 = { 12, 3, 7, 04, 9, 10, 8, 44, 29, 71 };
			Console.WriteLine("\n\nOriginal Array V1: ");
			foreach (int item in numbersV1) Console.Write(item.ToString("D2") + " ");
			Console.WriteLine();

			InsertionSortV1(numbersV1);
			foreach (int item in numbersV1) Console.Write(item.ToString("D2") + " ");


			Console.ReadLine();
		}
	}
}
