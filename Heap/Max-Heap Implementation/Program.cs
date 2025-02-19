namespace Max_Heap_Implementation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MaxHeap maxHeap = new MaxHeap();

			Console.WriteLine("Inserting elements into the Max-Heap...\n");
			maxHeap.Insert(10);
			maxHeap.Insert(4);
			maxHeap.Insert(15);
			maxHeap.Insert(2);
			maxHeap.Insert(8);

			// Display the heap after insertion
			maxHeap.DisplayHeap();

			Console.WriteLine("\nPeek Maximum Element: Maximum Element is: " + maxHeap.Peek());

			// Display the heap after insertion, note that the maximum value is not deleted.
			maxHeap.DisplayHeap();

			// Extract elements based on priority
			Console.WriteLine("\nExtracting elements from the Max-Heap:");
			Console.WriteLine("Extracted Maximum: " + maxHeap.ExtractMax());
			maxHeap.DisplayHeap();

			Console.WriteLine("\nExtracted Maximum: " + maxHeap.ExtractMax());
			maxHeap.DisplayHeap();

		}
	}
}
