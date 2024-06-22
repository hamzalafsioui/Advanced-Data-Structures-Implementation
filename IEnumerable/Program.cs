using System;
using System.Collections;
using System.Collections.Generic;


namespace CustomCollectionExample
{
	public class CustomCollection<T> : IEnumerable<T>
	{
		private List<T> items = new List<T>();


		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < items.Count; i++)
			{

				/*
                  yield return
                  Usage: The yield return statement is used within an iterator block to provide a value 
                   to the enumerator object and then pauses the execution of the iterator block 
                   until the next element is requested.
                  Functionality: When a yield return statement is executed, 
                   it returns the current value to the caller but remembers the current location 
                   in code for the next call. The next time the iterator is accessed, 
                   it resumes execution from the state it was left in, 
                   immediately after the last yield return statement.
                 
                 */
				yield return items[i];
			}
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}


		public void Add(T item)
		{
			items.Add(item);
		}

		public void Print()
		{
			if (items is null || items.Count == 0)
				return;
			Console.Write("[");
			for (int i = 0; i < items.Count; i++)
			{
				Console.Write(i);
				if (i < items.Count - 1)
					Console.Write(", ");


			}
			Console.WriteLine("]");
		}
		public bool IsEmpty()
		{
			return items.Count == 0 || items is null;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var myCollection = new CustomCollection<int>();
			myCollection.Add(1);
			myCollection.Add(2);
			myCollection.Add(3);
			myCollection.Print();
			Console.WriteLine("Is myCollection Empty: " + myCollection.IsEmpty());

			Console.ReadKey();
		}
	}
}
