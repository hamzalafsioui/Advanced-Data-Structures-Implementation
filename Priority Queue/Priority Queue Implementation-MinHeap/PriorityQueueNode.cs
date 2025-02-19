
namespace Priority_Queue_Implementation_MinHeap
{
	public class PriorityQueueNode
	{
		public PriorityQueueNode(string name, int priority)
		{
			Name = name;
			Priority = priority;
		}

		public string Name { get; set; }
		public int Priority { get; set; }

	}

	public class MinHeapPriorityQueue
	{
		private List<PriorityQueueNode> _heap = new List<PriorityQueueNode>();

		// Insert a new element with a priority
		public void Insert(string name, int priority)
		{
			var node = new PriorityQueueNode(name, priority);
			_heap.Add(node);
			HeapifyUp(_heap.Count - 1);
		}

		// Extract the element with the minimun priority
		public PriorityQueueNode ExtractMin()
		{
			if (_heap.Count == 0)
				throw new InvalidOperationException("Priority Queue is empty");

			var minNode = _heap[0];
			_heap[0] = _heap[_heap.Count - 1];
			_heap.RemoveAt(_heap.Count - 1);
			HeapifyDown(0);

			return minNode;
		}

		// Peek at the element with the minimum priority without removing it
		public PriorityQueueNode Peek()
		{
			if (_heap.Count == 0)
			{
				throw new InvalidOperationException("Priority Queue is empty.");
			}

			return _heap[0];
		}

		// Helper method to restore the heap property by bubbling down
		private void HeapifyDown(int index)
		{
			while (index < _heap.Count)
			{
				int leftChildIndex = 2 * index + 1;
				int rightChildIndex = 2 * index + 2;
				int smallestIndex = index;

				if (leftChildIndex < _heap.Count && _heap[leftChildIndex].Priority < _heap[smallestIndex].Priority)
					smallestIndex = leftChildIndex;

				if (rightChildIndex < _heap.Count && _heap[rightChildIndex].Priority < _heap[smallestIndex].Priority)
					smallestIndex = rightChildIndex;

				if (smallestIndex == index)
					break;

				// swap
				(_heap[index], _heap[smallestIndex]) = (_heap[smallestIndex], _heap[index]);

				// update index
				index = smallestIndex;

			}
		}

		private void HeapifyUp(int index)
		{
			while (index > 0)
			{
				int parentIndex = (index - 1) / 2;
				if (_heap[index].Priority >= _heap[parentIndex].Priority)
					break;

				//swap
				(_heap[index], _heap[parentIndex]) = (_heap[parentIndex], _heap[index]);

				index = parentIndex;
			}
		}
	}
}
