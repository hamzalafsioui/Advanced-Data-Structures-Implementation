namespace Priority_Queue_Implementation_MinHeap
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MinHeapPriorityQueue pq = new MinHeapPriorityQueue();

			Console.WriteLine("Inserting elements into the Priority Queue...\n");

			Console.WriteLine("Inserting (Task 1, 5)");
			Console.WriteLine("Inserting (Task 2, 3)");
			Console.WriteLine("Inserting (Task 3, 4)");
			Console.WriteLine("Inserting (Task 4, 1)");
			Console.WriteLine("Inserting (Task 5, 2)");

			pq.Insert("Task 1", 5);
			pq.Insert("Task 2", 3);
			pq.Insert("Task 3", 4);
			pq.Insert("Task 4", 1);
			pq.Insert("Task 5", 2);

			// Peek the minimum priority element
			Console.WriteLine("\nPeek Minimum Priority Element: Name = " + pq.Peek().Name + ", Priority = " + pq.Peek().Priority);

			// Extract elements based on priority
			Console.WriteLine("\nExtracting elements from the Priority Queue:");
			var extractedNode = pq.ExtractMin();
			Console.WriteLine("\nExtracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);

			extractedNode = pq.ExtractMin();
			Console.WriteLine("Extracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);

			extractedNode = pq.ExtractMin();
			Console.WriteLine("Extracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);

			extractedNode = pq.ExtractMin();
			Console.WriteLine("Extracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);

			extractedNode = pq.ExtractMin();
			Console.WriteLine("Extracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);



		}
	}
}
