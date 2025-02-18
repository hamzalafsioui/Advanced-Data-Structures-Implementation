namespace Min_Heap_Implementation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MinHeap minHeap = new MinHeap();

			Console.WriteLine("Inserting elements into the Min-Heap...\n");
			minHeap.Insert(10);
			minHeap.Insert(4);
			minHeap.Insert(15);
			minHeap.Insert(2);
			minHeap.Insert(8);

			// Display the heap after insertion
			minHeap.DisplayHeap();

			Console.WriteLine("\nPeek Minimum Element: Minimum Element is: " + minHeap.Peek());

			// Display the heap after insertion, note that the minimum value is not deleted.
			minHeap.DisplayHeap();

			// Extract elements based on priority
			Console.WriteLine("\nExtracting elements from the Min-Heap:");
			Console.WriteLine("Extracted Minimum: " + minHeap.ExtractMin());
			minHeap.DisplayHeap();

			Console.WriteLine("\nExtracted Minimum: " + minHeap.ExtractMin());
			minHeap.DisplayHeap();
		}
	}
}
